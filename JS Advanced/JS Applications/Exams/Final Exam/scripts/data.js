const appKey = "0A81F28E-C515-9523-FFF6-EB620A602A00";
const restKey = "6C581B52-9B91-469C-839F-8C9CC51ACBEE";

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

export async function createMovie(authorId, context) {
    await fetch(host(api.MOVIES), {
        method: "POST",
        body: JSON.stringify({authorId, ...context}),
        headers: {
            'Content-type': 'application/json'
        }
    })
}

export async function getMovieById(id) {
    return await (await fetch(host(api.MOVIES + "/" + id))).json()
}


export async function getMoviesByQuery(query) {
    const clause = `title LIKE '%${query}%'`;

    const queryBuilder = Backendless.DataQueryBuilder.create().setWhereClause(clause);

    return Backendless.Data.of("Movies").find(queryBuilder)
        .then((data) => {
            return data;
        });
}

export async function editMovie(movieId, context) {
    await fetch(host(api.MOVIES + "/" + movieId), {
        method: "PUT",
        body: JSON.stringify({...context}),
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

export async function likeMovie(userId, movieId) {
    const movie = await getMovieById(movieId);
    if (!movie.usersLiked) {
        movie.usersLiked = JSON.stringify([userId]);
    } else {
        movie.usersLiked.push(userId);
    }

    movie.likesCount += 1;
    await fetch(host(api.MOVIES + "/" + movieId), {
        method: "PUT",
        body: JSON.stringify(movie),
        headers: {
            'Content-type': 'application/json'
        }
    })
}

export async function hasUserLikedMovie(movieId, userId) {
    const movie = await getMovieById(movieId);
    if (movie.usersLiked){
        return movie.usersLiked.includes(userId);
    }
    return false;
}