function createArticle() {
    const title = document.getElementById("createTitle")
    const textArea = document.getElementById("createContent")

    const articles = document.getElementById("articles")
    const newArticle = document.createElement('article');
    const h3 = document.createElement('h3');
    const p = document.createElement("p")
    if (title.value !== '' && textArea.value !== '') {
        h3.innerHTML = title.value;
        p.innerHTML = textArea.value;

        newArticle.appendChild(h3);
        newArticle.appendChild(p);

        articles.appendChild(newArticle);

        h3.innerText = title.value;
        p.innerText = textArea.value;

        title.value = '';
        textArea.value = '';
    }
}