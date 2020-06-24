function solve() {
    const inputs = document.querySelectorAll("form > input");

    const [titleInput, yearInput, priceInput] = Array.from(inputs);

    const oldBooksDiv = document.querySelector("section > .bookShelf");
    const newBooksDiv = document.querySelector("section:last-of-type > .bookShelf");

    const addBtn = document.querySelector("form > button");

    addBtn.addEventListener("click", onAddBtnClick)

    function onAddBtnClick(e) {
        e.preventDefault();

        const yearInputValue = Number(yearInput.value);
        let priceInputValue = Number(priceInput.value);

        if (isNaN(yearInputValue) || yearInputValue < 0 || isNaN(priceInputValue) || priceInputValue < 0) {
            return;
        }

        let isOld = false;
        if (yearInputValue < 2000) {
            priceInputValue = priceInputValue * 0.85; //15% off
            isOld = true
        }

        const bookDiv = document.createElement("div")
        bookDiv.className = "book";

        const titleP = document.createElement("p")
        titleP.textContent = titleInput.value + ` [${yearInput.value}]`;

        const buyBtn = document.createElement("button");
        buyBtn.textContent = `Buy it only for ${priceInputValue.toFixed(2)} BGN`
        buyBtn.addEventListener("click", onBuyBtnClick)

        const moveBtn = document.createElement("button");
        moveBtn.textContent = "Move to old section"
        moveBtn.addEventListener("click", onMoveBtnClick)

        bookDiv.appendChild(titleP);
        bookDiv.appendChild(buyBtn);

        if (!isOld) {
            bookDiv.appendChild(moveBtn);
            newBooksDiv.appendChild(bookDiv);
        } else {
            oldBooksDiv.appendChild(bookDiv);
        }


    }

    function onBuyBtnClick(e) {
        const profitFromBook = Number(e.target.textContent.split(" ")[4]);
        const profitH1 = document.querySelector("form").nextElementSibling;

        if (!profitH1.value) {
            profitH1.value = profitFromBook;
        } else {
            profitH1.value = Number(profitH1.value) + profitFromBook;
        }

        profitH1.textContent = `Total Store Profit: ${profitH1.value} BGN`

        e.target.parentElement.remove()
    }

    function onMoveBtnClick(e) {

        const copy = e.target.parentElement;
        e.target.parentElement.remove();
        copy.removeChild(copy.lastChild);

        const newValue = Number(copy.children[1].textContent.split(" ")[4]) * 0.85; // Get the value from the string and parse it

        copy.children[1].textContent = `Buy it only for ${newValue.toFixed(2)} BGN`;

        oldBooksDiv.appendChild(copy);

    }
}