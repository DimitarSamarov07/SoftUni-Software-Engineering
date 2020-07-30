import {toggleError, toggleInfo, toggleLoading} from "../notifications.js";
import {
    allMovies,
    buyTicket,
    createMovie, deleteMovie,
    editMovie,
    getAllUserMovies,
    getMovieById,
    getMoviesByQuery
} from "../data.js";
import {validateMovieData} from "./validator.js";

export async function createMovieGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        createForm: await this.load('./templates/create/createForm.hbs')
    };

    this.partial("./templates/create/createPage.hbs", this.app.userData)
        .then(() => {
            $("#createMovieForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => toggleLoading(false))
}

export async function createMoviePost() {
    Backendless.UserService.getCurrentUser()
        .then(async (user) => {
            const title = this.params.title;
            const imageUrl = this.params.imageUrl;
            const description = this.params.description;
            const genres = this.params.genres;
            const ticketsCount = this.params.tickets;

            const isDataValid = await validateMovieData(title, description, imageUrl, ticketsCount);

            if (!isDataValid) {
                return;
            }

            const movie = {
                title,
                genres,
                description,
                imageUrl,
                authorId: user.objectId,
                ticketsCount: Number(ticketsCount),
            }

            await createMovie(movie)
                .then(() => {
                    toggleLoading(false);
                    toggleInfo(true, "Movie created successfully.");

                    setTimeout(function () {
                        this.redirect("#/");
                    }.bind(this), 1000)
                });
        })

}

export async function cinemaGet() {
    const movies = {movies: await allMovies()};

    const context = Object.assign(movies, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        cinemaMovie: await this.load('./templates/cinema/cinemaMovie.hbs')
    };

    this.partial("./templates/cinema/cinemaPage.hbs", context)
        .then(() => toggleLoading(false));
}

export async function detailsMovieGet() {
    const movie = await getMovieById(this.params.id);

    const context = Object.assign(movie, this.app.userData)

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        detailedMovie: await this.load('./templates/details/detailedMovie.hbs')
    };

    this.partial("./templates/details/detailsPage.hbs", context)
        .then(() => toggleLoading(false));
}

export async function searchByGenre() {
    const query = this.params.search;
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        cinemaMovie: await this.load('./templates/cinema/cinemaMovie.hbs')
    }

    getMoviesByQuery(query)
        .then(movies => {
            const context = Object.assign({movies}, this.app.userData);
            this.partial("./templates/cinema/cinemaPage.hbs", context)
                .then(() => toggleLoading(false));
        })
}

export async function buyTicketGet() {
    const movieId = this.params.movieId;

    const result = await buyTicket(movieId);
    toggleLoading(false);

    if (result) {
        toggleInfo(true, `"Successfully bought ticket for ${result.title}!"`)
        setTimeout(function () {
            this.redirect("#/cinema")
        }.bind(this))
    } else {
        toggleError("There are no available tickets right now. Sorry :(")
    }
}

/////////////////////////////////////
export async function myMoviesGet() {
    Backendless.UserService.getCurrentUser()
        .then(async (user) => {
            const context = {movies: await getAllUserMovies(user.objectId)};
            this.partials = {
                header: await this.load('./templates/common/header.hbs'),
                footer: await this.load('./templates/common/footer.hbs'),
                movie: await this.load('./templates/movies/movie.hbs')
            };
            Object.assign(context, this.app.userData);
            this.partial("./templates/movies/myMovies.hbs", context)
                .then(() => toggleLoading(false));
        })

}

export async function editMovieGet() {
    const movieId = this.params.id;
    const context = await getMovieById(movieId);

    Object.assign(context, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        editForm: await this.load('./templates/edit/editForm.hbs')
    };

    this.partial("./templates/edit/editPage.hbs", context)
        .then(() => {
            $("#editForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => toggleLoading(false));
}

export async function editMoviePost() {
    const {id, title, imageUrl, description, genres, ticketsCount} = this.params;

    const isDataValid = await validateMovieData(title, description, imageUrl, ticketsCount);

    if (!isDataValid) {
        return;
    }

    editMovie(id, title, description, genres, imageUrl, Number(ticketsCount))
        .then(() => {
            toggleLoading(false);
            toggleInfo(true, "Movie was successfully edited!")

            setTimeout(function () {
                this.redirect("#/")
            }.bind(this))
        })
        .catch();
}

export async function deleteMovieGet() {
    const movieId = this.params.id;

    const context = await getMovieById(movieId);
    Object.assign(context, this.app.data);


    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        deleteForm: await this.load('./templates/delete/deleteForm.hbs')
    };

    this.partial("./templates/delete/deletePage.hbs", context)
        .then(() => {
            $("#deleteForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => toggleLoading(false));
}

export async function deleteMoviePost() {
    const movieId = this.params.id;
    deleteMovie(movieId)
        .then(() => {
            toggleLoading(false);
            toggleInfo(true, "The movie was deleted successfully");

            setTimeout(function () {
                this.redirect("#/")
            }.bind(this))
        });
}