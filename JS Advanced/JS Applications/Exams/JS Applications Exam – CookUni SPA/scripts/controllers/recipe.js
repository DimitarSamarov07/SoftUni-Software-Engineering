import {toggleInfo, toggleLoading} from "../notifications.js";
import {validateRecipeData} from "../validator.js";
import {createRecipe, deleteRecipe, editRecipe, getRecipeById, likeRecipe} from "./data.js";

export async function createRecipetGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial('./templates/create/createPage.hbs', this.app.userData)
        .then(() => {
            $("#createForm").submit((e) => {
                e.preventDefault();
            })
        })
        .then(() => toggleLoading(false));
}

export async function createRecipePost() {
    if (await validateRecipeData(this.params)) {
        await createRecipe(this.app.userData.userId, this.params);
        toggleLoading(false);
        toggleInfo(true, "Recipe created successfully.")
        this.redirect("#/")
    }
}

export async function recipeDetailsGet() {
    const recipe = await getRecipeById(this.params.recipeId);

    const context = Object.assign(recipe, this.app.userData)
    context.isAuthor = this.app.userData.userId === recipe.authorId;

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial("./templates/details/detailsPage.hbs", context)
        .then(() => toggleLoading(false));
}

export async function editRecipeGet() {
    const {recipeId} = this.params;
    const recipe = await getRecipeById(recipeId);
    recipe.ingredients = recipe.ingredients.join(" ")


    const context = Object.assign({}, recipe, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial('./templates/edit/editPage.hbs', context)
        .then(() => {
            $("#editForm").submit((e) => {
                e.preventDefault();
            })

            $("select option").filter(function () {
                return $(this).text() === recipe.category;
            }).prop('selected', true);
        })
        .then(() => toggleLoading(false));
}

export async function editRecipePost() {
    const {recipeId} = this.params
    if (await validateRecipeData(this.params)) {
        delete this.params.recipeId;

        await editRecipe(recipeId, this.params);
        toggleLoading(false);
        toggleInfo(true, "Recipe created successfully.")
        this.redirect("#/")
    }
}

export async function likeRecipeGet() {
    const {recipeId} = this.params;
    await likeRecipe(recipeId);
    toggleLoading(false);
    toggleInfo(true, "Recipe likes successfully.")
    this.redirect("#/details/" + recipeId);
}

export async function deleteRecipeGet() {
    const {recipeId} = this.params;


    await deleteRecipe(recipeId);
    toggleInfo(true, "Recipe archived successfully.");
    toggleLoading(false);

    this.redirect("#/")
}