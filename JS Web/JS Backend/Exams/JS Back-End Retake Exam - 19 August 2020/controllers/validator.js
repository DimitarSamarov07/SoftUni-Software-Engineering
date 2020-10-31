const validateRegisterData = async (email, password, repeatPassword) => {
    if (!(/^([A-Za-z1-9]){3,}$/g.test(email))) {
        return "Email should be at least 3 characters long and consist only of english letters and digits."
    } else if (!(/^([A-Za-z1-9]){3,}$/g.test(password))) {
        return "Password should be at least 3 characters long and consist only of english letters and digits.";
    } else if (password !== repeatPassword) {
        return "Passwords do not match."
    }
}

module.exports = {
    validateRegisterData
}