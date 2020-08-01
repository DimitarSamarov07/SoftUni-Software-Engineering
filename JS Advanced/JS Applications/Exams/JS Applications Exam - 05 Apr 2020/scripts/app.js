import home from "./controllers/home.js";
import {loginGet, loginPost, logout, registerGet, registerPost} from "./controllers/users.js";
import {
    articleDetailsGet,
    createArticleGet,
    createArticlePost,
    deleteArticleGet,
    editArticleGet,
    editArticlePost
} from "./controllers/articles.js";

let userData = {
    loggedIn: false,
    username: undefined,
    userId: undefined,
};

Backendless.initApp("8E32119A-D9E3-8AF5-FFDD-6D1C5B454700", "15051110-26B1-42B4-9635-947FC0303519")
Backendless.UserService.getCurrentUser()
    .then(user => {
        if (user) {
            userData.loggedIn = true;
            userData.userId = user.objectId;
            userData.username = user.username;
        }
        const app = Sammy("#root", async function () {
            this.use('Handlebars', 'hbs');
            this.userData = userData;

            this.get("#/", home);
            this.get("/", home);

            this.get("#/login", loginGet)
            this.post("#/login", ctx => loginPost.call(ctx))

            this.get("#/register", registerGet)
            this.post("#/register", ctx => registerPost.call(ctx))

            this.get("#/logout", logout)


            this.get("#/create", createArticleGet)
            this.post("#/create", ctx => createArticlePost.call(ctx))

            this.get("#/details/:articleId", articleDetailsGet)

            this.get("#/edit/:articleId", editArticleGet)
            this.post("#/edit/:articleId", ctx => editArticlePost.call(ctx))

            this.get("#/delete/:articleId", deleteArticleGet)
        })

        app.run("#/")
    })
    .catch()