const {handleAuthenticated, checkIfAuthenticated, getCurrentUserUsernameFromRequest, decodeJwt, getCurrentUserIdFromRequest} = require("../controllers/auth.js");
const {createExpense, getExpenseById, deleteExpenseById} = require("../controllers/expense.js");
const {validateCreateExpenseData} = require("../controllers/validator.js");

const express = require("express");
const router = express.Router();
const moment = require('moment')

router.get("/create", handleAuthenticated, async (req, res) => {
    return res.render("create-expense", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        userID: await getCurrentUserIdFromRequest(req),
        isAuthenticated: await checkIfAuthenticated(req),
    })
})

router.post("/create", handleAuthenticated, async (req, res) => {
    debugger;
    const data = req.body;

    const reportParser = {
        "on": true,
        undefined: false,
    }

    let error = await validateCreateExpenseData(data);

    if (error) {
        return res.render("create-expense", {
            loggedInUsername: await getCurrentUserUsernameFromRequest(req),
            userID: await getCurrentUserIdFromRequest(req),
            isAuthenticated: await checkIfAuthenticated(req),
            error: error,
            ...data,
        })
    }

    const {userID: creator} = await decodeJwt(req.cookies["aid"]);
    data.report = reportParser[data.report];
    data.creator = creator;
    data.date = moment();

    await createExpense(data);

    return res.redirect("/");
})

router.get("/report/:id", handleAuthenticated, async (req, res) => {
    const expenseId = req.params.id;
    const expense = await getExpenseById(expenseId);

    if (!expense || !expense.report) {
        return res.redirect("/")
    }

    expense.parsedDate = moment(expense.date).format("YYYY-MM-DD");


    return res.render("report", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        isAuthenticated: await checkIfAuthenticated(req),
        userID: await getCurrentUserIdFromRequest(req),
        ...expense,
    })
})

router.get("/delete/:id", handleAuthenticated, async (req, res) => {
    const id = req.params.id;
    await deleteExpenseById(id);

    return res.redirect("/");
})

module.exports = router;