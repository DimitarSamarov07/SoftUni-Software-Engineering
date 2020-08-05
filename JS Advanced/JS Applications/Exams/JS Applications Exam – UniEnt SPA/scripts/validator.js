import {toggleError, toggleLoading} from "./notifications.js";

export async function validateEventData(context) {
    const {title, dateTime, description, imageUrl} = context;

    if (Object.values(context).some((value) => !(!!value))) {
        toggleError(true, "All the fields are required.")
        toggleLoading(false);
        return false;
    }

    if (title.length < 6) {
        toggleError(true, "Title must be at least 6 characters long.")
        toggleLoading(false);
        return false;
    }

    if (!moment(dateTime, "DD MMMM", true).isValid() &&
        !moment(dateTime, "DD MMMM - hh a", true).isValid()) {

        toggleError(true, "Date must be in valid format.")
        toggleLoading(false);
        return false;
    }

    if (description.length < 10) {
        toggleError(true, "Description must be at least 10 characters long.")
        toggleLoading(false);
        return false;
    }

    if (!imageUrl.startsWith("https://") && !imageUrl.startsWith("http://")) {
        toggleError(true, "Image URL must be in valid format.")
        toggleLoading(false);
        return false;
    }

    return true;
}