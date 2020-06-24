function solve() {
    const nameInput = document.querySelector("#add-new > input");
    const quantityInput = document.querySelector("#add-new > input:nth-of-type(2)");
    const priceInput = document.querySelector("#add-new > input:last-of-type");
    const filterInput = document.querySelector("div.filter > input")

    const myProductsUl = document.querySelector("#myProducts > ul");
    const availableProductsUl = document.querySelector("#products > ul");

    const totalPriceH1 = document.getElementById("add-new").nextElementSibling;

    const addBtn = document.querySelector("#add-new > button");
    addBtn.addEventListener("click", onAddBtnClick)

    const buyBtn = document.querySelector("#myProducts > button");
    buyBtn.addEventListener("click", onBuyBtnClick)

    const filterBtn = document.querySelector("div.filter > button");

    filterBtn.addEventListener("click", onFilterBtnClick)

    function onAddBtnClick(e) {
        const li = document.createElement("li");
        const div = document.createElement("div")

        const nameSpan = document.createElement("span");
        nameSpan.textContent = nameInput.value;

        const quantityStrong = document.createElement("strong");
        quantityStrong.textContent = `Available: ${quantityInput.value}`;

        const priceStrong = document.createElement("strong");
        priceStrong.textContent = Number(priceInput.value).toFixed(2);

        const addToListBtn = document.createElement("button");
        addToListBtn.textContent = "Add to Client's List"
        addToListBtn.addEventListener("click", onAddToListBtnClick);

        div.appendChild(priceStrong);
        div.appendChild(addToListBtn);

        li.appendChild(nameSpan);
        li.appendChild(quantityStrong);
        li.appendChild(div);

        availableProductsUl.appendChild(li);

        e.preventDefault();
    }

    function onFilterBtnClick() {
        const filterValue = filterInput.value;
        if (!filterValue) { // not required by Judge, added by me
            Array.from(availableProductsUl.children)
                .forEach(x => x.style.display = "block")
            return;
        }

        const lisToHide = Array.from(availableProductsUl.children)
            .filter(x => !x.firstChild.textContent.includes(filterValue));

        lisToHide.forEach(x => x.style.display = "none");

    }

    function onAddToListBtnClick(e) {
        let currPrice = totalPriceH1.textContent.split(" ")[2];
        currPrice = Number(currPrice);

        const quantityElement = e.target.parentElement.previousSibling;
        let [, quantity] = quantityElement.textContent.split(" "); //Ignore the text and get the value

        const liCopy = e.target.parentElement.parentElement.cloneNode(true); //clone the li
        const priceCopy = e.target.previousSibling.cloneNode(true); // clone the strong

        const priceValue = Number(priceCopy.textContent);

        liCopy.removeChild(liCopy.lastChild); //remove the div
        liCopy.removeChild(liCopy.lastChild) //remove the quantity
        const span = liCopy.removeChild(liCopy.firstChild) //remove the span and take it
        liCopy.textContent = span.textContent;
        liCopy.appendChild(priceCopy); //append the price's strong back

        quantity = Number(quantity);
        quantity--;
        quantityElement.textContent = `Available: ${quantity}`;

        currPrice += priceValue;
        totalPriceH1.innerText = `Total Price: ${currPrice.toFixed(2)}`;

        if (quantity <= 0) {
            e.target.parentElement.parentElement.remove();
        }

        myProductsUl.appendChild(liCopy);
    }

    function onBuyBtnClick() {
        totalPriceH1.innerText = `Total Price: 0.00`;
        myProductsUl.innerHTML = "";
    }

}