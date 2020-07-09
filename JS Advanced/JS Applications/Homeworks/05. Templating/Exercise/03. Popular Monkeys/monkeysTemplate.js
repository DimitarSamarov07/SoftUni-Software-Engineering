(async () => {
    await render();
    await attachEvents();

    async function render() {
        const monkeysDiv = document.querySelector("div.monkeys");

        const template = await fetch("template.hbs")
            .then(data => data.text());

        const monkeysTemplate = Handlebars.compile(template);

        const monkeys = window.monkeys;
        const context = {monkeys};

        monkeysDiv.innerHTML += monkeysTemplate(context);
    }

    async function attachEvents() {
        const buttons = document.querySelectorAll(".monkey > button");

        buttons.forEach((btn) => {
            btn.addEventListener("click", onBtnClick);
        })
    }

    async function onBtnClick(e) {
        const btn = e.target;
        const infoP = btn.nextElementSibling;

        //Not required, added by me
        const btnTextSwitch = {
            "Info": "Hide",
            "Hide": "Info",
        }

        const displayStyleSwitch = {
            "none": "block",
            "block": "none",
        }

        btn.textContent = btnTextSwitch[btn.textContent];

        infoP.style.display = displayStyleSwitch[infoP.style.display];

    }
})()