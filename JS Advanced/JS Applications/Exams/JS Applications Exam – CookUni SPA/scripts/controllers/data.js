const appKey = "E7E4F9CD-233A-27B5-FF91-7C0FFED24D00";
const restKey = "F3B45DE2-23AC-44D6-857A-D03D1A8B7F34";

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    RECIPES: 'data/Recipes',
    USERS: 'data/Users',
    // MEMBERS: '?loadRelations=members'
};

export async function getAllRecipes() {
    return await (await fetch(host(api.RECIPES))).json();
}

export async function getRecipeById(recipeId) {
    return await (await fetch(host(api.RECIPES + "/" + recipeId))).json();
}

export async function createRecipe(authorId, context) {
    context.ingredients = JSON.stringify(context.ingredients.split(" "));
    await fetch(host(api.RECIPES), {
        method: "POST",
        body: JSON.stringify({...context, authorId})
    })
}

export async function editRecipe(recipeId, context) {
    context.ingredients = JSON.stringify(context.ingredients.split(" "));

    await fetch(host(api.RECIPES + "/" + recipeId), {
        method: "PUT",
        body: JSON.stringify({...context}),
        headers: {
            'Content-type': 'application/json'
        }
    })

}

export async function likeRecipe(recipeId) {
    const recipe = await getRecipeById(recipeId);
    recipe.likesCount += 1;

    await fetch(host(api.RECIPES + "/" + recipeId), {
        method: "PUT",
        body: JSON.stringify(recipe),
    })
}

export async function deleteRecipe(recipeId) {
    await fetch(host(api.RECIPES + "/" + recipeId), {
        method: "DELETE"
    })
}