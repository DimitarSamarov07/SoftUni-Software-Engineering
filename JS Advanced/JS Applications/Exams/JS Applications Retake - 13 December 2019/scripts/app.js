import {toggleError, toggleInfo, toggleLoading} from "./notifications.js";
import home from "./controllers/home.js";
import {getUserProfile, loginGet, loginPost, logout, registerGet, registerPost} from "./controllers/users.js";
import {
    commentOnIdeaPost,
    createIdeaGet,
    createIdeaPost,
    deleteIdeaGet,
    ideaDetailsGet,
    likeIdeaGet
} from "./controllers/idea.js";
import dashboard from "./controllers/dashboard.js";

let userData = {
    loggedIn: false,
    username: undefined,
    userId: undefined,
};

Backendless.initApp("0AA1EDCD-8930-AF2E-FFC7-F643592ECB00", "92E71219-9B73-46F7-A399-0AF9B6A87055");

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

            this.before({}, async function () {
                toggleLoading(true);
                toggleError(false, null)
                toggleInfo(false, null);
            });

            this.get("#/", home);

            this.get("#/register", registerGet);
            this.post("#/register", ctx => registerPost.call(ctx))

            this.get("#/login", loginGet)
            this.post("#/login", ctx => loginPost.call(ctx))

            this.get("#/create", createIdeaGet);
            this.post("#/create", ctx => createIdeaPost.call(ctx))

            this.get("#/profile/:userId", getUserProfile)

            this.get("#/logout", logout);


            this.get("#/dashboard", dashboard)

            this.get("#/details/:ideaId", ideaDetailsGet)

            this.get("#/like/:ideaId", likeIdeaGet)

            this.get("#/delete/:ideaId", deleteIdeaGet)

            this.post("#/comment/:ideaId", ctx => commentOnIdeaPost.call(ctx));


        })

        app.run("#/")
    })