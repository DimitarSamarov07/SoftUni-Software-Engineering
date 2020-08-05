const appKey = "9AC3BE5C-EBB0-D397-FFD6-2A9E07C04600";
const restKey = "8FA313B7-F371-41F6-BA81-3F0ACABB5EEC";

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    EVENTS: 'data/Events',
    USERS: 'data/Users',
    // MEMBERS: '?loadRelations=members'
};


export async function getUserById(userId) {
    return await (await fetch(host(api.USERS + "/" + userId))).json();
}

export async function getUserEvents(userId) {
    const clause = `authorId LIKE '${userId}'`;

    const queryBuilder = Backendless.DataQueryBuilder.create().setWhereClause(clause);
    return Backendless.Data.of("Events").find(queryBuilder)
        .then(x => {
            return x;
        })
        .catch(err => {
            console.error(err);
        })
}

export async function getFullUserProfile(userId) {
    const user = await getUserById(userId);
    user.events = await getUserEvents(userId);

    return user;
}



export async function getAllEvents() {
    return await (await fetch(host(api.EVENTS))).json();
}

export async function getEventById(eventId) {
    return await (await fetch(host(api.EVENTS + "/" + eventId))).json();
}

export async function createEvent(authorId, context) {
    await fetch(host(api.EVENTS), {
        method: "POST",
        body: JSON.stringify({...context, authorId})
    })
}

export async function editEvent(eventId, context) {
    await fetch(host(api.EVENTS + "/" + eventId), {
        method: "PUT",
        body: JSON.stringify({...context}),
        headers: {
            'Content-type': 'application/json'
        }
    })

}


export async function deleteEvent(eventId) {
    await fetch(host(api.EVENTS + "/" + eventId), {
        method: "DELETE"
    })
}

export async function joinEvent(eventId) {
    const event = await getEventById(eventId);
    event.usersInterestedCount += 1;

    await fetch(host(api.EVENTS + "/" + eventId), {
        method: "PUT",
        body: JSON.stringify(event),
    })

}