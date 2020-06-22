function solve() {
    const authorInput = document.getElementById("creator");
    const titleInput = document.getElementById("title");
    const categoryInput = document.getElementById("category");
    const contentInput = document.getElementById("content");

    const createBtn = document.querySelector("button.create")

    createBtn.addEventListener("click", onCreateBtnClick)

    function onCreateBtnClick(e) {
        const articlesDiv = document.querySelector("div.site-content > main > section");

        const article = document.createElement("article");
        const buttonsDiv = document.createElement("div");
        buttonsDiv.className = "buttons";

        const titleH1 = document.createElement("h1");
        titleH1.textContent = titleInput.value;

        const categoryP = document.createElement("p");
        categoryP.innerText = "Category:";

        const categoryStrong = document.createElement("strong");
        categoryStrong.textContent = categoryInput.value;

        const creatorP = document.createElement("p");
        creatorP.innerText = "Creator:";

        const creatorStrong = document.createElement("strong");
        creatorStrong.textContent = authorInput.value;

        const contentP = document.createElement("p");
        contentP.textContent = contentInput.value;

        const deleteBtn = document.createElement("button")
        deleteBtn.className = "btn delete";
        deleteBtn.textContent = "Delete"

        deleteBtn.addEventListener("click", onDeleteBtnClick)

        const archiveBtn = document.createElement("button");
        archiveBtn.className = "btn archive";
        archiveBtn.textContent = "Archive"
        archiveBtn.addEventListener("click", orArchiveBtnClick)

        categoryP.appendChild(categoryStrong);
        creatorP.appendChild(creatorStrong);

        buttonsDiv.appendChild(deleteBtn);
        buttonsDiv.appendChild(archiveBtn);

        article.appendChild(titleH1);
        article.appendChild(categoryP);
        article.appendChild(creatorP);
        article.appendChild(contentP);
        article.appendChild(buttonsDiv);

        articlesDiv.appendChild(article);

        e.preventDefault();
    }

    function onDeleteBtnClick(e) {
        e.target.parentElement.parentElement.remove();
    }

    function orArchiveBtnClick(e) {
        const title = e.target.parentElement.parentElement.firstChild.textContent;

        const archiveUl = document.querySelector("section.archive-section > ul");

        const titleLi = document.createElement("li");
        titleLi.textContent = title;

        archiveUl.appendChild(titleLi);

        e.target.parentElement.parentElement.remove();

        sortList(archiveUl);
    }


    function sortList(ul) {
        const items = [...ul.querySelectorAll('li')];
        ul.innerHTML = '';
        items.sort(((a, b) => a.textContent.localeCompare(b.textContent))).forEach(li => ul.appendChild(li));
    }
}
