const {handleGuest, handleAuthenticated, decodeJwt} = require("../controllers/auth.js");
const {refillUserAmount, getUserById} = require("../controllers/user.js")
const {getUserExpenses} = require("../controllers/expense.js");

const express = require("express");
const router = express.Router();

router.post("/refill", handleAuthenticated, async (req, res) => {
    const userId = await (await decodeJwt(req.cookies["aid"])).userID;
    const amount = req.body.amount;

    await refillUserAmount(userId, amount);

    return res.redirect("/");
})

router.get("/profile/:id", handleAuthenticated, async (req, res) => {
    const userId = req.params.id;
    const user = await getUserById(userId);
    const expenses = await getUserExpenses(userId);

    const total = expenses.reduce((acc, curr) => {
        return acc += curr.total;
    }, 0);

    return res.render("account-info", {
        amount: user.amount,
        total,
        merchesCount: expenses.length,
    })
})

module.exports = router;