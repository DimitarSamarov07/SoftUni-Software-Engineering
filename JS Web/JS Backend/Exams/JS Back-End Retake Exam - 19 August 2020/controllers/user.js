const User = require("../models/user.js");

const getUserPurchases = async (userId) => {
    return (await User.findById(userId).populate("purchases")).purchases;
}
module.exports = {
    getUserPurchases
}