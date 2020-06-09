function solve() {
    let inputField = document.querySelector("#exercise > textarea:first-of-type");
    let outputField = document.querySelector("#exercise > textarea:last-of-type")
    const generateBtn = document.querySelector("#exercise > button:first-of-type");
    const buyBtn = document.querySelector("#exercise > button:last-of-type");

    generateBtn.addEventListener("click", onGenerateBtnClick)
    buyBtn.addEventListener("click", onBuyBtnClick)

    function onGenerateBtnClick() {
        let objects = JSON.parse(inputField.value);
        let tbody = document.querySelector("tbody")

        objects.forEach(x => {

            const mainTr = document.createElement("tr")

            const imgTd = document.createElement("td");
            const img = document.createElement("img")
            img.src = x.img;

            imgTd.appendChild(img)
            mainTr.appendChild(imgTd);

            const nameTd = document.createElement("td");
            const nameP = document.createElement("p")
            nameP.textContent = x.name;

            nameTd.appendChild(nameP);
            mainTr.appendChild(nameTd)

            const priceTd = document.createElement("td");
            const priceP = document.createElement("p")
            priceP.textContent = x.price;

            priceTd.appendChild(priceP);
            mainTr.appendChild(priceTd);

            const decFactorTd = document.createElement("td");
            const decFactorP = document.createElement("p")
            decFactorP.textContent = x.decFactor;

            decFactorTd.appendChild(decFactorP);
            mainTr.appendChild(decFactorTd);

            const checkboxTd = document.createElement("td")
            const checkbox = document.createElement("input")
            checkbox.type = "checkbox";

            checkboxTd.appendChild(checkbox);
            mainTr.appendChild(checkboxTd);

            tbody.appendChild(mainTr)
        })

        inputField.value = "";
    }

    function onBuyBtnClick() {
        let checkedCheckboxes = document.querySelectorAll("input[type=\"checkbox\"]:checked")
        let totalPrice = 0;
        let totalDecFactor = 0;
        let furnitureArr = [];

        Array.from(checkedCheckboxes).forEach(currCheckbox => {
            let decFacEl = currCheckbox.parentElement.previousElementSibling;
            let priceEl = decFacEl.previousElementSibling;
            let name = priceEl.previousElementSibling;

            totalPrice += +priceEl.textContent;
            totalDecFactor += +decFacEl.textContent;

            furnitureArr.push(name.textContent);

        })

        outputField.value = `Bought furniture: ${furnitureArr.join(", ")}\n` +
            `Total price: ${totalPrice.toFixed(2)}\n` +
            `Average decoration factor: ${totalDecFactor / checkedCheckboxes.length}`;
    }

}