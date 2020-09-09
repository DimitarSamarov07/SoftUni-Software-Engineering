const {getAllCubes, getCubesByCriteria} = require("../controllers/cubes.js");
const {checkIfAuthenticated} = require("../controllers/users.js");

const express = require("express");

const router = express.Router();

router.get("/", async (req, res) => {
    res.render("index", {
        title: "Cubicle",
        cubes: await getAllCubes(),
        isAuthenticated: await checkIfAuthenticated(req, res)
    });
})

router.get("/about", async (req, res) => {
    res.render("about", {
        title: "About Page",
        isAuthenticated: await checkIfAuthenticated(req, res)
    });
})


router.get("/search", async (req, res) => {
    const {keyword, from, to} = req.query;

    res.render("index", {
        title: "searchResults",
        cubes: await getCubesByCriteria(keyword, from, to),
        isAuthenticated: await checkIfAuthenticated(req, res)
    });
})

module.exports = router;