const mongoose = require('mongoose');

const CourseSchema = new mongoose.Schema({
    title: {
        type: String,
        required: true,
        unique: true
    },
    description: {
        type: String,
        required: true,
        maxlength: 50,
    },
    imageUrl: {
        type: String,
        required: true,
    },
    duration: {
        type: String,
        required: true,
    },
    createdAt: {
        type: Date,
        required: true
    },
    creator: {
        type: "ObjectId",
        ref: "User"
    },
    usersEnrolled: [{
        type: "ObjectId",
        ref: "User"
    }]
})

module.exports = mongoose.model('Course', CourseSchema)