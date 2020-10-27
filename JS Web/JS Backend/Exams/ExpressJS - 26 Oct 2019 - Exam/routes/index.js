const {getUserExpenses} = require("../controllers/expense.js");
const {checkIfAuthenticated, getCurrentUserUsernameFromRequest, getCurrentUserIdFromRequest} = require("../controllers/auth.js");

const express = require("express");
const router = express.Router();
const moment = require('moment');

router.get("/", async (req, res) => {
    const token = await getCurrentUserIdFromRequest(req);
    let expenses;
    const isAuthenticated = await checkIfAuthenticated(req);

    if (isAuthenticated) {
        expenses = await getUserExpenses(token);
    }
    if (expenses) {
        expenses.forEach(x => x.parsedDate = moment(x.date).format("YYYY-MM-DD"));
    }
    return res.render("home", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        userID: token,
        isAuthenticated,
        expenses
    });
})

module.exports = router;