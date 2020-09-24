const mongoose = require('mongoose');

const TripSchema = new mongoose.Schema({
    startPoint: {
        type: String,
        required: true,
    },
    endPoint: {
        type: String,
        required: true
    },
    date: {
        type: String,
        required: true,
    },
    time: {
        type: String,
        required: true,
    },
    seatsCount: {
        type: Number,
        required: true,
    },
    description: {
        type: String,
        required: true,
    },
    carImageUrl: {
        type: String,
        required: true,
    },
    creator: {
        type: "ObjectId",
        ref: "User",
        required: true
    },
    buddies: [{
        type: "ObjectId",
        ref: "User"
    }]

})

module.exports = mongoose.model('Trip', TripSchema)