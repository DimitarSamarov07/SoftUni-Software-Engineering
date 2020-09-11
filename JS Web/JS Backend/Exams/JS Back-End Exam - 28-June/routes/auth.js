const {verifyUserPassword, saveUser, handleGuest, handleAuthenticated} = require("../controllers/auth.js");
const express = require("express");
const router = express.Router();

router.get("/login", handleGuest, async (req, res) => {
    res.render("login", {
        title: "Login page",
    });
})

router.post("/login", handleGuest, async (req, res) => {
    const {
        username,
        password,
    } = req.body;

    let error;

    if (!/^[A-Za-z0-9]{3,}$/g.test(username)) {
        error = "The username should be at least 3 characters long and must consist only of english letters and digits."
    } else if (!/^[A-Za-z0-9]{3,}$/g.test(password)) {
        error = "The password should be at least 3 characters long and must consist only of english letters and digits."
    }

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
        title: "Register page",
    });
})

router.post("/register", async (req, res) => {

    const {
        username,
        password,
        repeatPassword
    } = req.body;

    let error;

    if (!/^[A-Za-z0-9]{3,}$/g.test(username)) {
        error = "The username should be at least 3 characters long and must consist only of english letters and digits."
    } else if (!/^[A-Za-z0-9]{3,}$/g.test(password)) {
        error = "The password should be at least 3 characters long and must consist only of english letters and digits."
    } else if (password !== repeatPassword) {
        error = "Passwords don't match."
    }

    if (error) {
        return res.render("register", {
            error: error,
            username,
            password,
            repeatPassword
        })
    }

    try {
        const token = await saveUser(username, password);
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