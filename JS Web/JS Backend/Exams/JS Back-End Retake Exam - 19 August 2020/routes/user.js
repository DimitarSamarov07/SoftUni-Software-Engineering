const {handleAuthenticated, decodeJwt, getCurrentUserUsernameFromRequest} = require("../controllers/auth.js");
const {getUserPurchases} = require("../controllers/user.js");

const express = require("express");
const router = express.Router();

router.get("/profile", handleAuthenticated, async (req, res) => {
    const {userID} = await decodeJwt(req.cookies["aid"]);

    const loggedInUsername = await getCurrentUserUsernameFromRequest(req);
    const purchases = await getUserPurchases(userID);
    const total = purchases.reduce((acc, curr) => {
        return acc += curr.price;
    }, 0)

    return res.render("profile", {
        loggedInUsername,
        purchases,
        total
    })
})

module.exports = router;