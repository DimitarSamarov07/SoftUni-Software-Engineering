const express = require("express");
const {getAllPlays} = require("../controllers/plays.js");
const {checkIfAuthenticated} = require("../controllers/auth.js");

const router = express.Router();

router.get("/", async (req, res) => {

    let allPlays = await getAllPlays();
    const bestPlays = [...allPlays].sort((a, b) => b.usersLiked.length - a.usersLiked.length).slice(0, 3)
    return res.render("index", {
        isAuthenticated: await checkIfAuthenticated(req),
        plays: allPlays,
        bestPlays: bestPlays,
    })
})

router.get("/sort", async (req, res) => {
    const sorter = {
        date: (plays) => plays.sort((a, b) => new Date(b.createdAt) - new Date(a.createdAt)),
        likes: (plays) => plays.sort((a, b) => b.usersLiked.length - a.usersLiked.length),
    }
    const plays = await getAllPlays();
    const sorted = sorter[req.query.criteria](plays)

    return res.render("index", {
        isAuthenticated: await checkIfAuthenticated(req),
        plays: sorted,
    })
})
module.exports = router;