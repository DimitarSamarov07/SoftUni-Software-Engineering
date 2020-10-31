const {checkIfAuthenticated, getCurrentUserUsernameFromRequest} = require("../controllers/auth.js");
const {getAllShoes} = require("../controllers/shoes.js");

const express = require("express");
const router = express.Router();
const moment = require('moment');

router.get("/", async (req, res) => {
    const isAuthenticated = await checkIfAuthenticated(req);
    let shoes;

    if (isAuthenticated) {
        shoes = await getAllShoes()
        shoes = shoes.sort((a, b) => b.buyers.length - a.buyers.length);
    }

    return res.render("home", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        isAuthenticated,
        shoes,
    });
})

module.exports = router;