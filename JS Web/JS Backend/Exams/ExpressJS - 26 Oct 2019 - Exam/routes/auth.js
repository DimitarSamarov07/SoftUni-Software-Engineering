const {verifyUserPassword, saveUser, handleGuest, handleAuthenticated, getCurrentUserUsernameFromRequest} = require("../controllers/auth.js");
const express = require("express");
const {validateRegisterData} = require("../controllers/validator.js");
const router = express.Router();

router.get("/login", handleGuest, async (req, res) => {
    res.render("login", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        title: "Login page",
    });
})

router.post("/login", handleGuest, async (req, res) => {
    const {
        username,
        password,
    } = req.body;

    let error;

    const token = await verifyUserPassword(username, password);

    if (!token && !error) {
        error = "Incorrect credentials. Please try again."
    }
    if (error) {
        return res.render("login", {
            error: error
        })
    }

    res.cookie("aid", token);

    res.redirect("/");
})

router.get("/register", handleGuest, async (req, res) => {
    res.render("register", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        title: "Register page",
    });
})

router.post("/register", handleGuest, async (req, res) => {

    let {
        username,
        password,
        amount,
        repeatPassword
    } = req.body;

    if (!amount) amount = 0;
    let error = await validateRegisterData(username, password, repeatPassword, amount);
    if (error) {
        return res.render("register", {
            error: error,
            ...req.body
        })
    }

    try {
        const token = await saveUser(username, password, amount);
        res.cookie("aid", token);
        return res.redirect("/");
    } catch (e) {
        error = "Username already exists."
        return res.render("register", {
            error: error,
            username,
            password,
            repeatPassword
        })
    }

})

router.get("/logout", handleAuthenticated, (req, res) => {
    res.clearCookie("aid");
    res.redirect("/");
})

module.exports = router;