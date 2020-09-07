const mongoose = require("mongoose");

const CubeSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
    },
    description: {
        type: String,
        required: true,
        maxlength: 2000
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
    accessories: [{
        type: "ObjectId",
        ref: "Accessory"
    }]
})

CubeSchema.path("imageUrl").validate((url) => {
    return url.startsWith("http") || url.startsWith("https")
}, "Image URL must start with http:// or https://")
module.exports = mongoose.model('Cube', CubeSchema);