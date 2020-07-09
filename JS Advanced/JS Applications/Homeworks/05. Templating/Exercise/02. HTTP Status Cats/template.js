(async () => {
    await renderCatTemplate();
    await attachEvents();

    async function renderCatTemplate() {
        const catsUl = document.querySelector("#allCats > ul");

        const cats = window.cats;
        const template = await fetch("template.hbs")
            .then(data => data.text());

        const catsTemplate = Handlebars.compile(template);
        const context = {cats}

        catsUl.innerHTML += catsTemplate(context);
    }

    async function attachEvents() {
        const buttons = document.querySelectorAll(".info > button");
        buttons.forEach((btn) => {
            btn.addEventListener("click", onBtnClick);
        })
    }

    async function onBtnClick(e) {
        const btn = e.target;
        const statusDiv = e.target.nextElementSibling;

        const btnTextSwitch = {
            "Show status code": "Hide status code",
            "Hide status code": "Show status code",
        }

        const displayStyleSwitch = {
            "none": "block",
            "block": "none",
        }

        btn.textContent = btnTextSwitch[btn.textContent];
        statusDiv.style.display = displayStyleSwitch[statusDiv.style.display];
    }

})();
