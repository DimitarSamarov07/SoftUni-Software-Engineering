const validateRegisterData = async (username, password, repeatPassword, amount) => {
    if (!(/^([A-Za-z1-9]){4,}$/g.test(username))) {
        return "Username should be at least 4 characters long and should consist only english letters and digits."
    } else if (password.length < 8) {
        return "Password should be at least 8 characters long."
    } else if (password !== repeatPassword) {
        return "Passwords do not match."
    } else if (isNaN(amount) || Number(amount) < 0) {
        return "Account amount should be positive number."
    }
}

const validateCreateExpenseData = async ({merchant, total, category, description}) => {
    const validCategories = ["advertising", "benefits", "car", "equipment", "fees",
        "home-office", "insurance", "interest", "Labor", "maintenance",
        "materials", "meals-and-entertainment", "office-supplies", "other",
        "professional-services", "rent", "taxes", "travel", "utilities"]

    if (merchant.length < 4) {
        return "Merchant should be at least 4 characters long.";
    } else if (isNaN(total) || total <= 0) {
        return "Total should be a positive number."
    } else if (!validCategories.includes(category)) {
        return "Category should one from the given options.";
    } else if (description.length < 10 || description.length > 50) {
        return "Description should be minimum 10 characters long and 50 characters maximum."
    }
}

module.exports = {
    validateRegisterData,
    validateCreateExpenseData
}