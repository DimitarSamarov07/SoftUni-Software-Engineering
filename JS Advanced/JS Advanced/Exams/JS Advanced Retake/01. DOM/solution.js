function solve() {
    const [screenUl, archiveUl] = document.querySelectorAll("ul");
    const [nameInput, hallInput, priceInput] = document.querySelectorAll("form > div > input");
    const [onScreenBtn, clearBtn] = document.querySelectorAll("button");
    onScreenBtn.addEventListener("click", onScreenBtnClick);
    clearBtn.addEventListener("click", onClearBtnClick)

    function onScreenBtnClick(e) {
        e.preventDefault();
        if (!nameInput.value || !hallInput.value || !priceInput.value || isNaN(priceInput.value)) {
            return;
        }

        const li = document.createElement("li");
        li.innerHTML = `<span>${nameInput.value}</span> <strong>Hall: ${hallInput.value}</strong>`;

        const div = document.createElement("div");
        div.innerHTML = `<strong>${Number(priceInput.value).toFixed(2)}</strong><input placeholder="Tickets Sold">`;

        const archiveBtn = document.createElement("button");
        archiveBtn.textContent = "Archive";
        archiveBtn.addEventListener("click", onArchiveBtnClick);


        div.appendChild(archiveBtn);
        li.appendChild(div);
        screenUl.appendChild(li);
        clearInputs();
    }

    function clearInputs() {
        nameInput.value = "";
        hallInput.value = "";
        priceInput.value = "";
    }

    function onArchiveBtnClick(e) {
        const target = e.target;
        const input = target.previousElementSibling;
        if (!input.value || isNaN(input.value)) {
            return;
        }
        const amount = Number(input.value);
        const price = Number(input.previousElementSibling.textContent);
        target.parentElement.parentElement.children[1].remove();
        const liNode = target.parentElement.parentElement;

        target.parentElement.remove();

        liNode.innerHTML += `<strong>Total amount: ${(price * amount).toFixed(2)}</strong>`;
        const deleteBtn = document.createElement("button");
        deleteBtn.textContent = "Delete";
        deleteBtn.addEventListener("click", onDeleteBtnClick)
        liNode.appendChild(deleteBtn);

        archiveUl.appendChild(liNode)
    }

    function onClearBtnClick(e) {
        archiveUl.innerHTML = "";
    }

    function onDeleteBtnClick(e) {
        e.target.parentElement.remove();
    }
}