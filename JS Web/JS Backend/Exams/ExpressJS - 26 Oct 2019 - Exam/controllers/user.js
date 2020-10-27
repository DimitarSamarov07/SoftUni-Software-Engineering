const User = require("../models/user.js");

const refillUserAmount = async (userId, amount) => {
    await User.findByIdAndUpdate(userId, {$inc: {amount: amount}});
}

const getUserById = async (userId) => {
    return User.findById(userId);
}

module.exports = {
    refillUserAmount,
    getUserById
}