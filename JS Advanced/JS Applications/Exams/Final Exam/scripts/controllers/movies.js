import {
    createMovie,
    deleteMovie,
    editMovie,
    getMovieById,
    getMoviesByQuery,
    hasUserLikedMovie,
    likeMovie
} from "../data.js";
import {toggleError, toggleInfo} from "../notifications.js";

export async function createMovieGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial('./templates/create/createPage.hbs', this.app.userData)
        .then(() => {
            $("#createForm").submit(function (e) {
                e.preventDefault();
            })
        })
}

export async function createMoviePost() {
    if (!Object.values(this.params).some(x => !x)) {
        await createMovie(this.app.userData.userId, this.params);
        toggleInfo(true, "Created successfully!")
        this.redirect("#/")
    } else {
        toggleError(true, "Invalid inputs!")
    }
}

export async function movieDetailsGet() {
    const {movieId} = this.params;
    const context = await getMovieById(movieId);
    context.isAuthor = this.app.userData.userId === context.authorId;
    context.hasUserLiked = await hasUserLikedMovie(movieId, this.app.userData.userId);

    Object.assign(context, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial('./templates/details/detailsPage.hbs', context)

}

export async function deleteMovieGet() {
    const {movieId} = this.params;
    await deleteMovie(movieId);
    toggleInfo(true, "Deleted successfully")

    this.redirect("#/");
}

export async function editMovieGet() {
    const {movieId} = this.params;
    const context = Object.assign({}, await getMovieById(movieId), this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial('./templates/edit/editPage.hbs', context)
        .then(() => {
            $("#editForm").submit(function (e) {
                e.preventDefault();
            })
        })
}

export async function editMoviePost() {
    const {movieId} = this.params;
    if (!Object.values(this.params).some(x => !x)) {
        delete this.params.movieId;
        await editMovie(movieId, this.params);
        toggleInfo(true, "Edited successfully")
        this.redirect("#/")
    } else {
        toggleError(true, "Invalid inputs!")
    }
}

export async function likeMovieGet() {
    const {movieId} = this.params;

    await likeMovie(this.app.userData.userId, movieId);
    toggleInfo(true, "Liked successfully");
    this.redirect("#/details/" + movieId);
}

export async function searchMovieGet() {
    const {query} = this.params;

    const context = Object.assign({},  this.app.userData);
    context.movies = await getMoviesByQuery(query);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loggedInHome: await this.load('./templates/home/loggedInHome.hbs'),
        guestHome: await this.load('./templates/home/guestHome.hbs')
    };

    this.partial('./templates/home/homePage.hbs', context)
}