import {toggleError, toggleLoading} from "./notifications.js";

export async function validateRecipeData(context) {
    const validCategories = ["Vegetables and legumes/beans", "Fruits", "Grain Food", "Milk, cheese, eggs and alternatives", "Lean meats and poultry, fish and alternatives"];
    const {meal, ingredients, category, description, prepMethod, imageUrl} = context;

    if (meal.length < 4) {
        toggleLoading(false);
        toggleError(true, "Meal should at least 4 characters long.")
        return false;
    }

    if (!ingredients.split(" ").length > 2) {
        toggleLoading(false);
        toggleError(true, "There should at least 2 ingredients, separated by a space.")
        return false;
    }

    if (!validCategories.includes(category)) {
        toggleLoading(false);
        toggleError(true, "Please select a category.")
        return false;
    }

    if (prepMethod.length < 10) {
        toggleLoading(false);
        toggleError(true, "Preparation method should at least 10 characters long.")
        return false;
    }

    if (description.length < 10) {
        toggleLoading(false);
        toggleError(true, "Description should at least 10 characters long.")
        return false;
    }

    if (!imageUrl.startsWith("http://") && !imageUrl.startsWith("https://")) {
        toggleLoading(false);
        toggleError(true, "Image URL should be in valid format.")
        return false;
    }

    return true;
}