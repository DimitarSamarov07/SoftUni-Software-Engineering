const mongoose = require("mongoose");

const Play = new mongoose.Schema({
    title: {
        type: String,
        required: true,
        unique: true
    },
    description: {
        type: String,
        required: true,
        maxlength: 50
    },
    imageUrl: {
        type: String,
        required: true
    },
    isPublic: {
        type: Boolean,
        default: false,
    },
    createdAt: {
        type: Date
    },
    creatorId: {
        type: "ObjectId",
        ref: "User",
    },
    usersLiked: [{
        type: "ObjectId",
        ref: "User"
    }]
})

module.exports = mongoose.model('Play', Play)