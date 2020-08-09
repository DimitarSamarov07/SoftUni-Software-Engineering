import home from "./controllers/home.js";
import {
    createMovieGet,
    createMoviePost,
    deleteMovieGet,
    editMovieGet,
    editMoviePost, likeMovieGet,
    movieDetailsGet, searchMovieGet
} from "./controllers/movies.js";
import {loginGet, loginPost, logout, registerGet, registerPost} from "./controllers/users.js";

let userData = {
    loggedIn: false,
    email: undefined,
    userId: undefined,
};

Backendless.initApp("0A81F28E-C515-9523-FFF6-EB620A602A00", "6C581B52-9B91-469C-839F-8C9CC51ACBEE");


Backendless.UserService.getCurrentUser()
    .then(user => {
        if (user) {
            userData.loggedIn = true;
            userData.userId = user.objectId;
            userData.email = user.email;
        }
        const app = Sammy("#container", async function () {
            this.use('Handlebars', 'hbs');
            this.userData = userData;

            this.get("#/", home)

            this.get("#/login", loginGet);
            this.post("#/login", ctx => loginPost.call(ctx))

            this.get("#/register", registerGet)
            this.post("#/register", ctx => registerPost.call(ctx))

            this.get("#/logout", logout)


            this.get("#/create", createMovieGet)
            this.post("#/create", ctx => createMoviePost.call(ctx))

            this.get("#/details/:movieId", movieDetailsGet);

            this.get("#/edit/:movieId", editMovieGet)
            this.post("#/edit/:movieId", ctx => editMoviePost.call(ctx));

            this.get("#/delete/:movieId", deleteMovieGet);

            this.get("#/like/:movieId", likeMovieGet);

            this.get("#/search", searchMovieGet)
        })

        app.run("#/")
    })