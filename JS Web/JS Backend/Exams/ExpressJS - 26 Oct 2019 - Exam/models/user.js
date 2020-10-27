const mongoose = require('mongoose');

const UserSchema = new mongoose.Schema({
    username: {
        type: String,
        required: true,
        unique: true,
        match: [/^[A-Za-z0-9]+$/gm, "The username can only contain English letters and digits"],
        minlength: [5, "The username should be at least 5 characters long"]
    },
    password: {
        type: String,
        required: true,
    },
    amount: {
        type: Number,
        default: 0,
    },
    expenses: [{
        type: "ObjectId",
        ref: "Expense"
    }]

})

module.exports = mongoose.model('User', UserSchema)