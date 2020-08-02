const appKey = "282AD663-6DD5-65E9-FF6E-6F80FDA14600";
const restKey = "33EA2382-0676-4A27-9D3C-74669291D0F3";

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    TREKS: 'data/Treks',
    USERS: 'data/Users',
    // MEMBERS: '?loadRelations=members'
};

export async function createTrek(organizerId, location, description, dateTime, imageUrl) {
    await fetch(host(api.TREKS), {
        method: "POST",
        body: JSON.stringify({organizerId, location, description, dateTime, imageUrl}),
    })
}

export async function getAllTreks() {
    return await (await fetch(host(api.TREKS))).json();
}

export async function getUserById(userId) {
    return await (await fetch(host(api.USERS + "/" + userId))).json()
}

export async function getTrekById(trekId) {
    return await (await fetch(host(api.TREKS + "/" + trekId))).json();
}

export async function getUserWishes(userId) {
    const clause = `organizerId = '${userId}'`;

    const queryBuilder = Backendless.DataQueryBuilder.create().setWhereClause(clause);
    return Backendless.Data.of("Treks").find(queryBuilder)
        .then((data) => {
            return data;
        });
}

export async function editTrek(trekId, location, description, dateTime, imageUrl) {
    await fetch(host(api.TREKS + "/" + trekId), {
        method: "PUT",
        body: JSON.stringify({location, description, dateTime, imageUrl}),
    })
}

export async function closeTrek(trekId) {
    await fetch(host(api.TREKS + "/" + trekId), {
        method: "DELETE"
    });
}

export async function likeTrek(trekId) {
    const trek = await getTrekById(trekId);
    trek.likesCount += 1;

    await fetch(host(api.TREKS + "/" + trekId), {
        method: "PUT",
        body: JSON.stringify(trek),
    })
}

export async function getFullUserProfile(userId) {
    const user = await getUserById(userId);
    const treks = await getUserWishes(userId);

    user.treks = treks.map(trek => trek.location);
    user.countOfTreks = treks.length;

    return user;
}