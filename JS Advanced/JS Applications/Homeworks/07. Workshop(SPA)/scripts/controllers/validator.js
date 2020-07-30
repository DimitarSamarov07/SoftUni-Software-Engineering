import {toggleError, toggleLoading} from "../notifications.js";

export async function validateMovieData(title, description, imageUrl, ticketsCount) {
    if (title.length < 6) {
        toggleLoading(false);
        toggleError(true, "Title should be at least 6 characters long.")
        return false;
    } else if (description.length < 10) {
        toggleLoading(false);
        toggleError(true, "Description should be at least 10 characters long.")
        return false;
    } else if (!imageUrl.startsWith("https://") && !imageUrl.startsWith("http://")) {
        toggleLoading(false);
        toggleError(true, "Image url should be valid.")
        return false;
    } else if (!Number.isInteger(Number(ticketsCount)) || Number(ticketsCount) <= 0) {
        toggleLoading(false);
        toggleError(true, "Tickets should be a valid, positive integer number")
        return false;
    } else {
        return true;
    }
}