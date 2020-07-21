const templates = {};
const baseUrl = "https://my-furniture-e8f7d.firebaseio.com"
const [loadingBox, infoBox, errorBox] = document.getElementById("notifications").children
toggleLoader();

function loadTemplate(templatePath) {
    const currTemplate = templates[templatePath]
    if (currTemplate) {
        return new Promise((resolve) => resolve(currTemplate));
    }

    return fetch(`templates/${templatePath}.hbs`)
        .then(data => data.text())
        .then(templateCode => {
            const templateFunc = Handlebars.compile(templateCode);

            templates[templatePath] = templateFunc;

            return templateFunc;
        })
}

async function renderTemplate(templatePath, templateContext, swapFn) {
    return loadTemplate(templatePath)
        .then((template) => swapFn(template(templateContext)));
}

function toggleLoader(show) {
    if (show) {
        loadingBox.style.display = "inline-block";
        return;
    }
    loadingBox.style.display = "none";
}

function onCreateFurnitureLoaded(redirectFn) {
    const make = document.getElementById("new-make");
    const year = document.getElementById("new-year");
    const model = document.getElementById("new-model");
    const description = document.getElementById("new-description");
    const price = document.getElementById("new-price");
    const image = document.getElementById("new-image");
    const material = document.getElementById("new-material");
    const createBtn = document.getElementById("createBtn");

    createBtn.addEventListener("click", async () => {
        if (make.value.length < 4 || model.value.length < 4
            || Number(year.value) < 1950 || Number(year.value) > 2050
            || isNaN(Number(year.value)) || description.value.length < 10
            || Number(price.value) < 0 || isNaN(Number(price.value))
            || !image.value) {
            toggleError(true);
            return;
        }
        toggleError(false);

        const context = {
            make: make.value,
            year: year.value,
            model: model.value,
            description: description.value,
            price: price.value,
            image: image.value,
            material: material.value
        };
        const bodyToSubmit = JSON.stringify(context);

        const response = await fetch(`${baseUrl}/furniture.json`, {
            method: "POST",
            body: bodyToSubmit,
        })
            .then(redirectFn("#/furniture/all"))

        console.log(response);
    })
}

function toggleError(show) {
    if (show) {
        errorBox.style.display = "inline-block";
        return;
    }
    errorBox.style.display = "none";
}

async function fetchFurniture(id) {
    let idUrlPart = ""
    if (id) {
        idUrlPart = `/${id}`
    }
    return fetch(`${baseUrl}/furniture${idUrlPart}.json`)
        .then(data => data.json())
        .then(furniture => {
            if (id) {
                return furniture;
            }
            return Object.keys(furniture).reduce((acc, currId) => {
                const currItem = furniture[currId];
                return acc.concat({id: currId, ...currItem});
            }, [])
        });

}

async function loadRegisterPartialTemplate(templatePath, templateName) {
    const template = await fetch(`templates/partials/${templatePath}.hbs`)
        .then(data => data.text());
    Handlebars.registerPartial(templateName, template)
}

const app = Sammy("#container", async function () {
        this.before({}, function () {
            toggleLoader(true);
        })

        this.get("#/", async () => {
            renderTemplate("home", {}, this.swap.bind(this))
                .then(() => toggleLoader(false))
        })

        this.get("#/furniture/create", function () {
            renderTemplate("createFurniture", {}, this.swap.bind(this))
                .then(() => toggleLoader(false))
                .then(() => {
                    onCreateFurnitureLoaded(this.redirect.bind(this));
                })
        })

        this.get("#/furniture/mine", function () {
            renderTemplate("myFurniture", {}, this.swap.bind(this))
                .then(() => toggleLoader(false))
        })
        this.get("#/furniture/details/:id", function (context) {
            const id = context.params.id;

            fetchFurniture(id)
                .then(furniture => {
                    renderTemplate("furnitureDetails", {furniture}, this.swap.bind(this))
                        .then(() => toggleLoader(false))
                })


        })

        this.get("#/furniture/all", async function () {
            await loadRegisterPartialTemplate("furnitureItem", "furnitureItem");
            fetchFurniture()
                .then(furniture => {
                    renderTemplate("listFurniture", {furniture}, this.swap.bind(this))
                        .then(() => toggleLoader(false))
                })


        })
    }
)

app.run("#/");