const Expense = require("../models/expense.js");
const User = require("../models/user.js");

const getUserExpenses = async (userId) => {
    return Expense.find({creator: userId});
}

const createExpense = async (args) => {
    const expense = new Expense(args);
    await expense.save();

    await User.findByIdAndUpdate(args.creator.toString()).lean(false).update({
        $addToSet: {
            expenses: [expense._id.toString()]
        },
    });
}

const getExpenseById = async (id) => {
    return Expense.findById(id);
}

const deleteExpenseById = async (id) => {
    await Expense.findByIdAndDelete(id);
}

module.exports = {
    getUserExpenses,
    createExpense,
    getExpenseById,
    deleteExpenseById
}