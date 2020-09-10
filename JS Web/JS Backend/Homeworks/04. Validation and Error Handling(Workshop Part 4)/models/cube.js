const mongoose = require("mongoose");

const CubeSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        match: [/^[A-Za-z0-9\s]+$/gm, "The name can only contain English letters, digits and whitespaces."],
    },
    description: {
        type: String,
        required: true,
        match: [/^[A-Za-z0-9\s]+$/gm, "The description can only contain English letters, digits and whitespaces."],
        minlength: [20, "The description should be at least 20 characters long."],
        maxlength: [2000, "The description length can't exceed 2000 characters."]
    },
    imageUrl: {
        type: String,
        required: true,
    },
    difficulty: {
        type: Number,
        min: 1,
        max: 6
    },
    creatorId: {
        type: "ObjectId",
        ref: "User",
    },
    accessories: [{
        type: "ObjectId",
        ref: "Accessory"
    }]
})

CubeSchema.path("imageUrl").validate((url) => {
    return url.startsWith("http") || url.startsWith("https")
}, "The image URL must start with http:// or https://")
module.exports = mongoose.model('Cube', CubeSchema);