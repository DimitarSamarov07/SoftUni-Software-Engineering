const {verifyUserPassword, saveUser, handleGuest, handleAuthenticated, validateEmail} = require("../controllers/auth.js");
const express = require("express");
const router = express.Router();

router.get("/login", handleGuest, async (req, res) => {
    res.render("login", {
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
        title: "Register page",
    });
})

router.post("/register", async (req, res) => {
    const {
        email,
        password,
        repeatPassword
    } = req.body;

    let error;

    if (!validateEmail(email)) {
        error = "Invalid email format."
    } else if (password.length < 6) {
        error = "The password should be at least 6 characters long."
    } else if (password !== repeatPassword) {
        error = "Passwords do not match.";
    }

    if (error) {
        return res.render("register", {
            error: error
        })
    }

    try {
        const token = await saveUser(email, password);
        res.cookie("aid", token);
        return res.redirect("/");
    } catch (e) {
        error = "Email already exists."
        return res.render("register", {
            error
        })
    }

})

router.get("/logout", handleAuthenticated, (req, res) => {
    res.clearCookie("aid");
    res.redirect("/");
})

module.exports = router;