import {toggleError} from "./notifications.js";

const appKey = "6390246F-C3EF-3BAA-FFB6-9DEC1FE25300";
const restKey = "EE4FB9A0-CCCC-4C95-AB37-E4D3BE00FA34";

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    TEAMS: 'data/Teams',
    USERS: 'data/Users',
    MEMBERS: '?loadRelations=members'
};

export async function teamMembers(teamId) {
    const loadRelationsQueryBuilder = Backendless.LoadRelationsQueryBuilder.create().setRelationName('members');

    return Backendless.Data.of('Teams').loadRelations(teamId, loadRelationsQueryBuilder)
}

export async function getTeam(teamId) {
    return (await fetch(host(api.TEAMS) + "/" + teamId + api.MEMBERS)).json();
}

export async function allTeams() {
    return (await fetch(host(api.TEAMS))).json();
}

export async function getUserTeam(userId) {
    const clause = `members.objectId LIKE '${userId}'`;

    const queryBuilder = Backendless.DataQueryBuilder.create().setWhereClause(clause);
    return Backendless.Data.of("Teams").find(queryBuilder)
        .then(x => {
            return x;
        })
        .catch(err => {
            console.error(err);
        })
}

export async function leaveTeam(userId) {

    const [{objectId: userTeamId}] = await getUserTeam(userId);

    const url = host(api.TEAMS + `/${userTeamId}` + api.MEMBERS);
    const teamWithMembers = await (await fetch(url)).json();


    let teamMembers = teamWithMembers.members.map(m => m.objectId);
    const userIndex = teamMembers.indexOf(userId);

    if (userIndex < 0) {
        toggleError('You are not a member of that team!');
        return;
    }

    teamMembers.splice(userIndex, 1);

    await (await fetch(host(api.TEAMS) + `/${userTeamId}/members`, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(teamMembers)
    })).json();

}

export async function joinTeam(userId, teamId, hasTeam) {
    if (hasTeam) {
        await leaveTeam(userId);
    }
    await (await fetch(host(api.TEAMS + `/${teamId}/members`), {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify([userId])
    })).json();
}

export async function editTeam(userId, teamId, newName, newDescription) {
    const team = await getTeam(teamId);

    if (team.authorId !== userId) {
        toggleError("Nope. Don't touch something that's not yours, kid :)")
        throw "HAHA";
    }


    await fetch(host(api.TEAMS) + `/${teamId}`, {
        method: "PUT",
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({name: newName, description: newDescription})
    })
}
