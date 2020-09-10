const {handleGuest, verifyUserPassword, saveUser} = require("../controllers/users.js");
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

    const token = await verifyUserPassword(username, password)
    if (token) {
        res.cookie("aid", token);
    } else {
        return res.render("login", {
            title: "Login page",
            error: "Incorrect credentials."
        });
    }

    res.redirect("/");
})

router.get("/register", handleGuest, async (req, res) => {
    res.render("register", {
        title: "Register page",
    });
})

router.post("/register", handleGuest, async (req, res) => {
    const {
        username,
        password,
        repeatPassword
    } = req.body;

    const token = await saveUser(username, password, repeatPassword);

    if (token.hasOwnProperty("error")) {
        return res.render("register", {
            title: "Register page",
            error: token.error,
        })
    }

    if (!token) { //passwords don't match
        return res.redirect("/register");
    }

    res.cookie("aid", token);

    res.redirect("/");
})

router.get("/logout", (req, res) => {
    res.clearCookie("aid");
    res.redirect("/");
})
module.exports = router;