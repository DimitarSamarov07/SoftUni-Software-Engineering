const express = require("express");
const {decodeJwt} = require("../controllers/auth.js");
const {checkIfAuthenticated} = require("../controllers/auth.js");

const router = express.Router();

router.get("/", async (req, res) => {
    const user = await decodeJwt(req.cookies["aid"]);
    return res.render("index", {
        isAuthenticated: await checkIfAuthenticated(req),
        loggedInEmail: user.email,
    })
})

module.exports = router;