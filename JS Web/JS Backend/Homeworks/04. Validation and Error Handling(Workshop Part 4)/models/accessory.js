const mongoose = require('mongoose');

const AccessorySchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        match: [/^[A-Za-z0-9\s]+$/gm, "The name can only contain English letters, digits and whitespaces."],
    },
    description: {
        type: String,
        required: true,
        minlength: [20, "The description should be at least 20 characters long."],
        maxlength: [2000, "The description length can't exceed 2000 characters."]
    },
    imageUrl: {
        type: String,
        required: true,
    },
    cubes: [{
        type: "ObjectId",
        ref: "Cube"
    }]
})

AccessorySchema.path("imageUrl").validate((url) => {
    return url.startsWith("http") || url.startsWith("https")
}, "The image URL must start with http:// or https://")

module.exports = mongoose.model('Accessory', AccessorySchema);