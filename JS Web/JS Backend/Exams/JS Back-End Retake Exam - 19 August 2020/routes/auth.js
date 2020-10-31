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
        email,
        password,
    } = req.body;

    let error;

    const token = await verifyUserPassword(email, password);

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
        email,
        password,
        repeatPassword,
        fullName
    } = req.body;

    let error = await validateRegisterData(email, password, repeatPassword);
    if (error) {
        return res.render("register", {
            error: error,
            ...req.body
        })
    }

    try {
        const token = await saveUser(email, password, fullName);
        res.cookie("aid", token);
        return res.redirect("/");
    } catch (e) {
        error = "Username already exists."
        return res.render("register", {
            error: error,
            username: email,
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