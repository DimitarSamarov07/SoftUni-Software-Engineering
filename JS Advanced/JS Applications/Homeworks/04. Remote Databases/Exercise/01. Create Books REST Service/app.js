function attachEvents() {
    const tbody = document.querySelector("tbody");
    const form = document.querySelector("form")

    const [titleInput, authorInput, isbnInput] = document
        .querySelectorAll("form > input");

    const loadBooksBtn = document.getElementById("loadBooks");
    loadBooksBtn.addEventListener("click", onLoadBooksBtnClick)

    const submitFormBtn = document.querySelector("form > button")
    submitFormBtn.addEventListener("click", onSubmitFormBtnClick)

    async function onLoadBooksBtnClick() {
        const url = "https://books-rest-service.firebaseio.com/Books.json";

        const books = await fetch(url)
            .then(data => data.json())
            .catch(() => console.warn("Sorry server is dead :/"));

        tbody.innerHTML = "";

        for (const [key, value] of Object.entries(books)) {
            await renderBook(key, value);
        }

    }

    async function onSubmitFormBtnClick(e) {
        e.preventDefault();

        if (!e.target.parentElement.hasAttribute("edit")) {

            const url = `https://books-rest-service.firebaseio.com/Books.json`;
            const objToPost = {
                title: titleInput.value,
                author: authorInput.value,
                isbn: isbnInput.value
            };

            await fetch(url, {
                method: "POST",
                body: JSON.stringify(objToPost)
            })
                .then(onLoadBooksBtnClick) //reload
                .then(() => form.reset()); // clear form;
        } else {
            await edit();
        }

    }

    async function edit() {
        const idToEdit = form.getAttribute("edit")

        const url = `https://books-rest-service.firebaseio.com/Books/${idToEdit}.json`;

        const objToPut = {
            title: titleInput.value,
            author: authorInput.value,
            isbn: isbnInput.value
        };

        await fetch(url, {
            method: "PUT",
            body: JSON.stringify(objToPut)
        })
            .then(() => onLoadBooksBtnClick()) //reload

        form.removeAttribute("edit")

    }

    async function onEditBtnClick(e) {
        const dataId = e.target.parentElement.parentElement.getAttribute("data-id")
        form.setAttribute("edit", dataId);

        const [titleInput, authorInput, isbnInput] = document
            .querySelectorAll("form > input");

        const url = `https://books-rest-service.firebaseio.com/Books/${dataId}.json`;

        const {title, author, isbn} = await fetch(url)
            .then(data => data.json());

        titleInput.value = title;
        authorInput.value = author;
        isbnInput.value = isbn;

        form.reset();
    }

    function onDeleteBtnClick(e) {
        const dataId = e.target.parentElement.parentElement
            .getAttribute("data-id");

        const url = `https://books-rest-service.firebaseio.com/Books/${dataId}.json`;

        fetch(url, {
            method: "DELETE"
        })
            .then(onLoadBooksBtnClick); //reload
    }

    async function renderBook(id, {title, author, isbn}) {
        const tr = document.createElement("tr");
        tr.setAttribute("data-id", id);

        tr.innerHTML += `
                <td>${title}</td>
                <td>${author}</td>
                <td>${isbn}</td>
                <td>
                </td>`;

        const editBtn = document.createElement("button");
        editBtn.textContent = "Edit";
        editBtn.addEventListener("click", onEditBtnClick)

        const deleteBtn = document.createElement("button");
        deleteBtn.textContent = "Delete";
        deleteBtn.addEventListener("click", onDeleteBtnClick);

        tr.lastElementChild.append(editBtn, deleteBtn)
        tbody.appendChild(tr)

    }
}

attachEvents();