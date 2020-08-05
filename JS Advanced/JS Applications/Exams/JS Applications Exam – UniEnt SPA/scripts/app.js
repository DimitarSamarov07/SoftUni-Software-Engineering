import {
    createEventGet,
    createEventPost,
    deleteEventGet,
    editEventGet, editEventPost,
    eventDetailsGet,
    joinEventGet
} from "./controllers/event.js";
import home from "./controllers/home.js";
import {loginGet, loginPost, logout, registerGet, registerPost, userProfileGet} from "./controllers/users.js";
import {readyNotifications, toggleLoading} from "./notifications.js";

let userData = {
    loggedIn: false,
    username: undefined,
    userId: undefined,
};

Backendless.initApp("9AC3BE5C-EBB0-D397-FFD6-2A9E07C04600", "8FA313B7-F371-41F6-BA81-3F0ACABB5EEC");

readyNotifications();

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
            });

            this.get("#/", home)

            this.get("#/login", loginGet);
            this.post("#/login", ctx => loginPost.call(ctx));

            this.get("#/register", registerGet);
            this.post("#/register", ctx => registerPost.call(ctx));

            this.get("#/profile/:userId", userProfileGet)

            this.get("#/logout", logout)


            this.get("#/create", createEventGet);
            this.post("#/create", ctx => createEventPost.call(ctx));

            this.get("#/details/:eventId", eventDetailsGet);

            this.get("#/close/:eventId", deleteEventGet);

            this.get("#/join/:eventId", joinEventGet)

            this.get("#/edit/:eventId", editEventGet);
            this.post("#/edit/:eventId", ctx => editEventPost.call(ctx));

        })

        app.run("#/")
    })