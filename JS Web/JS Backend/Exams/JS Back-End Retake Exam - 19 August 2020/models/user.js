const mongoose = require('mongoose');

const UserSchema = new mongoose.Schema({
    email: {
        type: String,
        required: true,
        unique: true,
    },
    fullName: {
        type: String
    },
    password: {
        type: String,
        required: true,
    },
    purchases: [{
        type: "ObjectId",
        ref: "Shoe"
    }]

})

module.exports = mongoose.model('User', UserSchema)