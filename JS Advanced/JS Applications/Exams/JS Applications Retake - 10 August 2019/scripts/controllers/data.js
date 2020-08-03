const appKey = "F1C2C3A7-14A1-B631-FF74-426249023D00";
const restKey = "6E37D534-7D9B-46CF-AF26-2329112D171E";

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    CAUSES: 'data/Causes',
    USERS: 'data/Users',
};

export async function getAllCauses() {
    return await (await fetch(host(api.CAUSES))).json();
}

export async function getCauseById(causeId) {
    return await (await fetch(host(api.CAUSES + "/" + causeId))).json();
}

export async function createCause(authorId, title, description, fundsGoal, imageUrl) {
    fundsGoal = Number(fundsGoal);
    await fetch(host(api.CAUSES), {
        method: "POST",
        body: JSON.stringify({authorId, title, description, fundsGoal, imageUrl})
    })
}

export async function donateToCause(causeId, donorName, amount) {
    const cause = await getCauseById(causeId);
    if (cause.donors) {
        const donors = cause.donors;
        if (!donors.includes(donorName)) {
            donors.push(donorName);
            cause.donors = JSON.stringify(donors);
        }
    } else {
        cause.donors = JSON.stringify([donorName]);
    }

    cause.raisedFunds += Number(amount);

    await fetch(host(api.CAUSES + "/" + causeId), {
        method: "PUT",
        body: JSON.stringify(cause)
    });
}

export async function deleteCause(causeId) {
    await fetch(host(api.CAUSES + "/" + causeId), {
        method: "DELETE"
    })
}