import {toggleError, toggleInfo, toggleLoading} from "./notifications.js";
import home from "./controllers/home.js";
import {getUserProfile, loginGet, loginPost, logout, registerGet, registerPost} from "./controllers/users.js";
import {
    closeTrekGet,
    createTrekGet,
    createTrekPost,
    editTrekGet,
    editTrekPost,
    likeGet,
    trekDetailsGet
} from "./controllers/trek.js";

let userData = {
    loggedIn: false,
    username: undefined,
    userId: undefined,
};

Backendless.initApp("282AD663-6DD5-65E9-FF6E-6F80FDA14600", "33EA2382-0676-4A27-9D3C-74669291D0F3");

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

            this.get("#/login", loginGet);
            this.post("#/login", ctx => loginPost.call(ctx));

            this.get("#/register", registerGet);
            this.post("#/register", ctx => registerPost.call(ctx));

            this.get("#/profile/:userId", getUserProfile);

            this.get("#/logout", logout);


            this.get("#/create", createTrekGet);
            this.post("#/create", ctx => createTrekPost.call(ctx));

            this.get("#/details/:trekId", trekDetailsGet);

            this.get("#/edit/:trekId", editTrekGet);
            this.post("#/edit/:trekId", editTrekPost);

            this.get("#/close/:trekId", closeTrekGet);

            this.get("#/like/:trekId", likeGet)

        })

        app.run("#/")
    })