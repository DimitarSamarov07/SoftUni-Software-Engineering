const appKey = "8E32119A-D9E3-8AF5-FFDD-6D1C5B454700";
const restKey = "15051110-26B1-42B4-9635-947FC0303519";

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    ARTICLES: 'data/Articles',
};

export async function createArticle(authorId, title, category, content) {
    await fetch(host(api.ARTICLES), {
        method: "POST",
        body: JSON.stringify({authorId, title, content, category})
    })
}

export async function getAllArticles() {
    return (await fetch(host(api.ARTICLES))).json()
}

export async function getArticleById(articleId) {
    return await (await fetch(host(api.ARTICLES + "/" + articleId))).json();
}

export async function editArticle(articleId, title, category, content) {
    const article = await getArticleById(articleId);
    article.title = title;
    article.category = category;
    article.content = content;

    await fetch(host(api.ARTICLES + "/" + articleId), {
        method: "PUT",
        body: JSON.stringify(article),
    })
}

export async function deleteArticle(articleId) {
    await fetch(host(api.ARTICLES + "/" + articleId), {
        method: "DELETE"
    })
}