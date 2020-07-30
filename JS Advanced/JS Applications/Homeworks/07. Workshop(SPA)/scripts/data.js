const appKey = "556F4273-A081-16FC-FF0E-4ECF489FC700";
const restKey = "C16D1110-2470-424A-9E7D-9E0364F92872";

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    MOVIES: 'data/Movies',
    USERS: 'data/Users',
    // MEMBERS: '?loadRelations=members'
};

export async function allMovies() {
    return (await fetch(host(api.MOVIES))).json();
}

export async function createMovie(obj) {
    await fetch(host(api.MOVIES), {
        method: "POST",
        body: JSON.stringify(obj),
        headers: {
            'Content-type': 'application/json'
        }
    })
}

export async function getMovieById(id) {
    return await (await fetch(host(api.MOVIES + "/" + id))).json()
}

export async function getAllUserMovies(userId) {
    const clause = `authorId = '${userId}'`;

    const queryBuilder = Backendless.DataQueryBuilder.create().setWhereClause(clause);
    return Backendless.Data.of("Movies").find(queryBuilder)
        .then((data) => {
            return data;
        });
}

export async function buyTicket(movieId) {
    const movie = await getMovieById(movieId);

    if (Number(movie.ticketsCount) - 1 < 0) {
        return false;
    }

    movie.ticketsCount -= 1;

    await (await fetch(host(api.MOVIES + "/" + movieId), {
        method: "PUT",
        body: JSON.stringify(movie),
        headers: {
            'Content-type': 'application/json'
        }
    })).json()

    return movie;
}

export async function getMoviesByQuery(query) {
    const clause = `genres LIKE '%${query}%'`;

    const queryBuilder = Backendless.DataQueryBuilder.create().setWhereClause(clause);

    return Backendless.Data.of("Movies").find(queryBuilder)
        .then((data) => {
            return data;
        });
}

export async function editMovie(movieId, title, description, genres, imageUrl, ticketsCount) {
    const movie = await getMovieById(movieId);
    movie.title = title;
    movie.description = description;
    movie.ticketsCount = ticketsCount;
    movie.genres = genres;
    movie.imageUrl = imageUrl;

    await fetch(host(api.MOVIES + "/" + movieId), {
        method: "PUT",
        body: JSON.stringify(movie),
        headers: {
            'Content-type': 'application/json'
        }
    })

}

export async function deleteMovie(movieId) {
    await fetch(host(api.MOVIES + "/" + movieId), {
        method: "DELETE"
    })
}