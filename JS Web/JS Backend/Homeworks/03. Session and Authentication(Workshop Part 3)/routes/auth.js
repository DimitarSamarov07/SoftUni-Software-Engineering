const {handleGuest, verifyUserPassword, saveUser, checkIfAuthenticated} = require("../controllers/users.js");
const express = require("express");
const router = express.Router();

router.get("/login", handleGuest, async (req, res) => {
    res.render("login", {
        title: "Login page",
        isAuthenticated: await checkIfAuthenticated(req, res)
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
        res.redirect("/login");
        return;
    }

    res.redirect("/");
})

router.get("/register", handleGuest, async (req, res) => {
    res.render("register", {
        title: "Register page",
        isAuthenticated: await checkIfAuthenticated(req, res)
    });
})

router.post("/register", handleGuest, async (req, res) => {
    const {
        username,
        password,
        repeatPassword
    } = req.body;
    const token = await saveUser(username, password, repeatPassword);

    if (!token) { //passwords don't match
        res.redirect("/register");
        return;
    }

    res.cookie("aid", token);

    res.redirect("/");
})

router.get("/logout", (req, res) => {
    res.clearCookie("aid");
    res.redirect("/");
})
module.exports = router;