const mongoose = require('mongoose');

const ExpenseSchema = new mongoose.Schema({
    merchant: {
        type: String,
        required: true
    },
    date: {
        type: Date,
        required: true
    },
    total: {
        type: Number,
        required: true
    },
    category: {
        type: String,
        required: true
    },
    description: {
        type: String,
        required: true
    },
    report: {
        type: Boolean,
        required: true
    },
    creator: {
        type: "ObjectId",
        ref: "User",
        required: true
    },
})

module.exports = mongoose.model('Expense', ExpenseSchema)