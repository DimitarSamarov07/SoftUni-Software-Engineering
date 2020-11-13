const validateRegisterData = async (username, password, repeatPassword) => {
    if (!(/^([A-Za-z0-9]){5,}$/g.test(username))) {
        return "Username should be at least 5 characters long and should consist only of english letters and digits."
    } else if (!(/^([A-Za-z0-9]){5,}$/g.test(password))) {
        return "Password should be at least 5 characters long and should consist only of english letters and digits."
    } else if (password !== repeatPassword) {
        return "Passwords do not match."
    }
}

const validateCourseData = async ({title, description, imageUrl}) => {
    if (title.length < 4) {
        return "Title should be at least 4 character long."
    } else if (description.length < 20) {
        return "Description should be at least 20 characters long.";
    } else if (!imageUrl.startsWith("http://") && !imageUrl.startsWith("https://")) {
        return "Image URL should be valid.(only http and https are allowed)";
    }
}


module.exports = {
    validateRegisterData,
    validateCourseData
}