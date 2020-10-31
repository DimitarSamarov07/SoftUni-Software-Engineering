const mongoose = require("mongoose");

const ShoeSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        unique: true
    },
    price: {
        type: Number,
        min: 0,
        default: 0,
        required: true
    },
    imageUrl: {
        type: String,
        required: true,
    },
    brand: {
        type: String,
        required: true,
    },
    description: {
        type: String,
        required: true,
    },
    createdAt: {
        type: Date,
        required: true,
    },
    creator: {
        type: "ObjectId",
        ref: "User",
        required: true,
    },
    buyers: [{
        type: "ObjectId",
        ref: "User"
    }]

})

module.exports = mongoose.model('Shoe', ShoeSchema)