const {getAllCubes, getCubeById, getCubesByCriteria} = require("../controllers/cubes.js");


const express = require("express");
const Cube = require("../models/cube.js");
const router = express.Router();

router.get("/", (req, res) => {
    res.render("index", {
        title: "Cubicle",
        cubes: getAllCubes()
    });
})

router.get("/create", ((req, res) => {
    res.render("create", {
        title: "Create Cube Page",
    });
}))

router.post("/create", ((req, res) => {

    Object.keys(req.body).map(k => req.body[k] = req.body[k].trim());
    const {
        name,
        description,
        imageURL,
        difficultyLevel
    } = req.body;

    const cube = new Cube(name, description, imageURL, Number(difficultyLevel));
    cube.save();
    res.redirect("/");
}))

router.get("/about", ((req, res) => {
    res.render("about", {
        title: "About Page",
    });
}))

router.get("/details/:id", ((req, res) => {
    const cube = getCubeById(req.params.id);
    res.render("details", {
        title: "Cubicle",
        ...cube
    });
}))

router.get("/search", ((req, res) => {
    const {keyword, from, to} = req.query;

    res.render("index", {
        title: "searchResults",
        cubes: getCubesByCriteria(keyword, from, to),
    });
}))

router.get("*", ((req, res) => {
    res.render("404", {
        title: "Page Not Found",
    })
}))

module.exports = router;