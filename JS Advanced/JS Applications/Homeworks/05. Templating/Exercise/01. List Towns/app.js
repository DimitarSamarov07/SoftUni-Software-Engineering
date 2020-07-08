async function attachEvents() {
    const townsInput = document.getElementById("towns");
    const loadTownsBtn = document.getElementById("btnLoadTowns");
    const rootUl = document.querySelector("#root > ul");

    loadTownsBtn.addEventListener("click", onLoadTownsBtnClick)

    async function onLoadTownsBtnClick(e) {
        e.preventDefault();
        const towns = townsInput.value.split(", ");

        const template = await fetch("template.hbs")
            .then(data => data.text());

        const context = {towns};

        const townsTemplate = Handlebars.compile(template);

        rootUl.innerHTML += townsTemplate(context);
    }
}

attachEvents();