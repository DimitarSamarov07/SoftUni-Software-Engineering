function solve() {
    const nameInput = document.querySelector("#add > div > input:first-of-type");
    const ageInput = document.querySelector("#add > div > input:nth-of-type(2)");
    const kindInput = document.querySelector("#add > div > input:nth-of-type(3)");
    const currentOwnerInput = document.querySelector("#add > div > input:last-of-type");

    const adoptionUl = document.querySelector("#adoption > ul")
    const adoptedUl = document.querySelector("#adopted > ul")

    const addBtn = document.querySelector("#add > div > button");
    addBtn.addEventListener("click", onAddBtnClick)

    function onAddBtnClick(e) {
        e.preventDefault();

        if (!nameInput.value || isNaN(Number(ageInput.value)) || !kindInput.value || !currentOwnerInput.value) {
            return;
        }

        const li = document.createElement("li");

        const p = document.createElement("p");
        p.innerHTML = `<strong>${nameInput.value}</strong> is a <strong>${ageInput.value}</strong> year old <strong>${kindInput.value}</strong>`

        const spanOwner = document.createElement("span");
        spanOwner.textContent = `Owner: ${currentOwnerInput.value}`;

        const contactOwnerBtn = document.createElement("button");
        contactOwnerBtn.textContent = "Contact with owner";
        contactOwnerBtn.addEventListener("click", onContactOwnerBtnClick);

        li.appendChild(p);
        li.appendChild(spanOwner);
        li.appendChild(contactOwnerBtn);

        adoptionUl.appendChild(li)

        clearInput();
    }

    function clearInput() {
        nameInput.value = "";
        ageInput.value = "";
        kindInput.value = "";
        currentOwnerInput.value = "";
    }

    function onContactOwnerBtnClick(e) {
        const newDivWithInput = document.createElement("div");
        newDivWithInput.innerHTML = "<input placeholder='Enter your names'><button>Yes! I take it!</button>";
        const takeItBtn = newDivWithInput.lastElementChild;
        takeItBtn.addEventListener("click", onTakeItBtn)

        const parent = e.target.parentElement;
        e.target.remove();
        parent.appendChild(newDivWithInput)

    }

    function onTakeItBtn(e) {
        const newOwnerInput = e.target.previousSibling;
        if (!newOwnerInput.value) {
            return;
        }
        const liParent = e.target.parentElement.parentElement;
        liParent.removeChild(liParent.lastChild.previousSibling);
        e.target.parentElement.remove();

        liParent.innerHTML += `<span>New Owner: ${newOwnerInput.value}</span> <button>Checked</button>`;

        adoptedUl.appendChild(liParent);

        const checkBtn = liParent.lastElementChild;
        checkBtn.addEventListener("click", onCheckBtn)
    }

    function onCheckBtn(e) {
        e.target.parentElement.remove();
    }
}

