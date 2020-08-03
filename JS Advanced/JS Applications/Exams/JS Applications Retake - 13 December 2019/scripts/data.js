const appKey = "0AA1EDCD-8930-AF2E-FFC7-F643592ECB00";
const restKey = "92E71219-9B73-46F7-A399-0AF9B6A87055";

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    IDEAS: 'data/Ideas',
    COMMENTS: 'data/Comments',
    USERS: 'data/Users',
    COMMENTS_RELATION: '?loadRelations=comments'
};

export async function getAllIdeas() {
    return await (await fetch(host(api.IDEAS))).json()
}

export async function getIdeaById(ideaId) {
    return await (await fetch(host(api.IDEAS + "/" + ideaId + api.COMMENTS_RELATION))).json();
}

export async function getUserById(userId) {
    return await (await fetch(host(api.USERS + "/" + userId))).json();
}

export async function getUserIdeas(userId) {
    const clause = `authorId LIKE '${userId}'`;

    const queryBuilder = Backendless.DataQueryBuilder.create().setWhereClause(clause);
    return Backendless.Data.of("Ideas").find(queryBuilder)
        .then(x => {
            return x;
        })
        .catch(err => {
            console.error(err);
        })
}

export async function getFullUserProfile(userId) {
    const user = await getUserById(userId);
    user.ideas = await getUserIdeas(userId);

    return user;
}

export async function createIdea(authorId, title, description, imageUrl) {
    await fetch(host(api.IDEAS), {
        method: "POST",
        body: JSON.stringify({authorId, title, description, imageUrl})
    })
}

export async function commentOnIdea(ideaId, displayName, content) {
    const {objectId: commentId} = await (await fetch(host(api.COMMENTS), {
        method: "POST",
        body: JSON.stringify({displayName, content})
    })).json()

    await fetch(host(api.IDEAS + "/" + ideaId + "/comments"), {
        method: "PUT",
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify([commentId])
    })
}

export async function deleteIdea(ideaId) {
    await fetch(host(api.IDEAS + "/" + ideaId), {
        method: "DELETE"
    })
}

export async function like(ideaId) {
    const idea = await getIdeaById(ideaId);
    idea.likesCount += 1;

    await fetch(host(api.IDEAS + "/" + ideaId), {
        method: "PUT",
        body: JSON.stringify(idea),
    })
}