import {toggleError, toggleInfo, toggleLoading} from "./notifications.js";
import home from "./controllers/home.js";
import {loginGet, loginPost, logout, registerGet, registerPost} from "./controllers/users.js";
import {
    buyTicketGet,
    cinemaGet,
    createMovieGet,
    createMoviePost, deleteMovieGet, deleteMoviePost,
    detailsMovieGet, editMovieGet, editMoviePost, myMoviesGet,
    searchByGenre
} from "./controllers/movies.js";

let userData = {
    loggedIn: false,
    username: undefined,
    userId: undefined,
};

Backendless.initApp("556F4273-A081-16FC-FF0E-4ECF489FC700", "C16D1110-2470-424A-9E7D-9E0364F92872");

Backendless.UserService.getCurrentUser()
    .then(user => {
        if (user){
            userData.loggedIn = true;
            userData.userId = user.objectId;
            userData.username = user.username;
        }
        const app = Sammy("#container", async function () {
            this.use('Handlebars', 'hbs');
            this.userData = userData;

            this.before({}, async function () {
                toggleLoading(true);
                toggleError(false, null)
                toggleInfo(false, null);
            });

            this.get("#/", home)

            this.get("#/login", loginGet);
            this.post("#/login", ctx => loginPost.call(ctx))

            this.get("#/register", registerGet)
            this.post("#/register", ctx => registerPost.call(ctx))

            this.get("#/logout", logout)


            this.get("#/add", createMovieGet)
            this.post("#/add", ctx => createMoviePost.call(ctx))

            this.get("#/cinema", cinemaGet);
            this.get("#/details/:id", detailsMovieGet)

            this.get("#/search", searchByGenre)

            this.get("#/buy/:movieId", buyTicketGet)
            this.get("#/movies", myMoviesGet)

            this.get("#/edit/:id", editMovieGet)
            this.post("#/edit/:id", ctx => editMoviePost.call(ctx))

            this.get("#/delete/:id", deleteMovieGet)
            this.post("#/delete/:id", ctx => deleteMoviePost.call(ctx));
        })

        app.run("#/")
    })