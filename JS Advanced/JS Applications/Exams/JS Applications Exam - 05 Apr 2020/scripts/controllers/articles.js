import {createArticle, deleteArticle, editArticle, getArticleById} from "../data.js";

export async function createArticleGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        createForm: await this.load('./templates/create/createForm.hbs'),
    };

    this.partial("./templates/create/createPage.hbs")
        .then(() => {
            $("#createForm").submit(function (e) {
                e.preventDefault();
            });
        })
}

export async function createArticlePost() {
    const {title, category, content} = this.params;

    Backendless.UserService.getCurrentUser()
        .then(async (user) => {
            await createArticle(user.objectId, title, category, content)
                .then(() => {
                    this.redirect("#/");
                });
        })
}

export async function articleDetailsGet() {
    const {articleId} = this.params;
    const article = await getArticleById(articleId);

    const context = Object.assign({}, article, this.app.userData);
    Backendless.UserService.getCurrentUser()
        .then(async (user) => {
            context.isAuthor = article.authorId === user.objectId;
            this.partials = {
                header: await this.load('./templates/common/header.hbs'),
                footer: await this.load('./templates/common/footer.hbs'),
            };

            this.partial("./templates/details/detailsPage.hbs", context);
        })
}

export async function editArticleGet() {
    const {articleId} = this.params;
    const article = await getArticleById(articleId);
    const context = Object.assign({}, article, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        editForm: await this.load('./templates/edit/editForm.hbs'),
    };

    this.partial("./templates/edit/editPage.hbs", context)
        .then(() => {
            $("#editForm").submit(function (e) {
                e.preventDefault();
            });
        });

}

export async function editArticlePost() {
    const {articleId, title, category, content} = this.params;
    await editArticle(articleId, title, category, content)
        .then(() => {
            this.redirect("#/")
        })
        .catch()
}

export async function deleteArticleGet() {
    const {articleId} = this.params;
    await deleteArticle(articleId)
        .then(() => {
            this.redirect("#/")
        });
}