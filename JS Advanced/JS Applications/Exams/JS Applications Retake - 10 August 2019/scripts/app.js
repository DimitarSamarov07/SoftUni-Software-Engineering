import {toggleError, toggleInfo, toggleLoading} from "./notifications.js";
import home from "./controllers/home.js";
import {loginGet, loginPost, logout, registerGet, registerPost} from "./controllers/users.js";
import {causeDetailsGet, createCauseGet, createCausePost, donateToCausePost} from "./controllers/cause.js";
import dashboard from "./controllers/dashboard.js";

let userData = {
    loggedIn: false,
    username: undefined,
    userId: undefined,
};

Backendless.initApp("F1C2C3A7-14A1-B631-FF74-426249023D00", "6E37D534-7D9B-46CF-AF26-2329112D171E");

Backendless.UserService.getCurrentUser()
    .then(user => {
        if (user){
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
            this.post("#/login", ctx => loginPost.call(ctx))

            this.get("#/register", registerGet);
            this.post("#/register", ctx => registerPost.call(ctx))

            this.get("#/logout", logout);

            this.get("#/create", createCauseGet)
            this.post("#/create", createCausePost)

            this.get("#/dashboard", dashboard)

            this.get("#/details/:causeId", causeDetailsGet)

            this.post("#/donate/:causeId", ctx => donateToCausePost.call(ctx))

        })

        app.run("#/")
    })