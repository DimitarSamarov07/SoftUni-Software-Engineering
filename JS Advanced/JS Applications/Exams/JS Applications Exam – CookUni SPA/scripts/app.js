import home from "./controllers/home.js";
import {
    createRecipePost,
    createRecipetGet,
    deleteRecipeGet,
    editRecipeGet,
    editRecipePost,
    likeRecipeGet,
    recipeDetailsGet
} from "./controllers/recipe.js";
import {loginGet, loginPost, logout, registerGet, registerPost} from "./controllers/users.js";
import {readyNotifications, toggleLoading} from "./notifications.js";

let userData = {
    loggedIn: false,
    username: undefined,
    userId: undefined,
    firstName: undefined,
    lastName: undefined,
};

Backendless.initApp("E7E4F9CD-233A-27B5-FF91-7C0FFED24D00", "F3B45DE2-23AC-44D6-857A-D03D1A8B7F34");

readyNotifications();

Backendless.UserService.getCurrentUser()
    .then(user => {
        if (user) {
            userData.loggedIn = true;
            userData.userId = user.objectId;
            userData.username = user.username;
            userData.firstName = user.firstName;
            userData.lastName = user.lastName;
        }
        const app = Sammy("#rooter", async function () {
            this.use('Handlebars', 'hbs');
            this.userData = userData;

            this.before({}, async function () {
                toggleLoading(true);
            });

            this.get("#/", home);

            this.get("#/login", loginGet);
            this.post("#/login", ctx => loginPost.call(ctx));

            this.get("#/register", registerGet);
            this.post("#/register", ctx => registerPost.call(ctx));

            this.get("#/logout", logout)


            this.get("#/create", createRecipetGet);
            this.post("#/create", ctx => createRecipePost.call(ctx));

            this.get("#/details/:recipeId", recipeDetailsGet);

            this.get("#/archive/:recipeId", deleteRecipeGet);

            this.get("#/edit/:recipeId", editRecipeGet);
            this.post("#/edit/:recipeId", ctx => editRecipePost.call(ctx));

            this.get("#/like/:recipeId", likeRecipeGet)

        })

        app.run("#/")
    })