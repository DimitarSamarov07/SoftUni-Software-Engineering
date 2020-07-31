import home from "./controllers/home.js";
import {loginGet, loginPost, logout, registerGet, registerPost} from "./controllers/users.js";
import {createPost, deleteGet, editGet, editPost} from "./controllers/posts.js";

let userData = {
    loggedIn: false,
    hasTeam: false,
    email: undefined,
    userId: undefined,
    teamId: undefined,
};
Backendless.initApp("36850755-1086-A166-FF48-0D75CB216500", "2A6DDE1E-C00C-415C-8A77-63BEA82C7FAD");

Backendless.UserService.getCurrentUser()
    .then(user => {
        if (user) {
            userData.loggedIn = true;
            userData.userId = user.objectId;
            userData.email = user.email;
        }

        const app = Sammy("#root", async function () {
            this.use('Handlebars', 'hbs');
            this.userData = userData;

            this.get("#/", home)

            this.get("#/login", loginGet);
            this.post("#/login", ctx => loginPost.call(ctx))

            this.get("#/register", registerGet)
            this.post("#/register", ctx => registerPost.call(ctx))

            this.get("#/logout", logout);

            this.post("#/create", ctx => createPost.call(ctx));

            this.get("#/delete/:id", deleteGet)
            this.get("#/edit/:id", editGet)
            this.post("#/edit/:id", ctx => editPost.call(ctx));
        });

        app.run("#/")
    });
