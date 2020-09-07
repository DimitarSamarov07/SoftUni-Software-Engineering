const {getAllCubes, getCubeById, getCubesByCriteria, getCubeWithAccessories, updateCube} = require("../controllers/cubes.js");
const {getAccessories} = require("../controllers/accessories.js");

const express = require("express");
const Cube = require("../models/cube.js");
const Accessory = require("../models/accessory.js");

const router = express.Router();

router.get("/", async (req, res) => {
    res.render("index", {
        title: "Cubicle",
        cubes: await getAllCubes()
    });
})

router.get("/create", (req, res) => {
    res.render("create", {
        title: "Create Cube Page",
    });
})

router.post("/create", (req, res) => {

    Object.keys(req.body).map(k => req.body[k] = req.body[k].trim());
    const {
        name,
        description,
        imageUrl,
        difficultyLevel
    } = req.body;

    const cube = new Cube({name, description, imageUrl, difficulty: Number(difficultyLevel)});
    cube.save(err => {
        if (err) {
            console.log(err);
            throw err;
        }

        res.redirect("/");
    });
})

router.get("/about", (req, res) => {
    res.render("about", {
        title: "About Page",
    });
})

router.get("/details/:id", async (req, res) => {
    const cube = await getCubeWithAccessories(req.params.id);
    res.render("details", {
        title: "Cubicle",
        ...cube
    });
})

router.get("/create/accessory", (req, res) => {
    res.render("createAccessory", {
        title: "Create accessory"
    })
})

router.post("/create/accessory", (req, res) => {
    const accessory = new Accessory({...req.body});
    accessory.save((err) => {
        if (err) {
            console.log(err);
            throw err;
        }

        res.redirect("/");
    })
})

router.get("/attach/accessory/:id", async (req, res) => {
    const cube = await getCubeById(req.params.id);

    let accessories = await getAccessories();
    const notAttachedAccessories = accessories.filter(accessory => cube.accessories.find(x => x._id.toString() !== accessory._id.toString()));

    res.render("attachAccessory", {
        title: "Attach accessory",
        ...cube,
        accessories: notAttachedAccessories,
        areAllAccessoriesEquipped: cube.accessories.length === accessories.length
    })
})

router.post("/attach/accessory/:id", async (req, res) => {
    const {accessoryId} = req.body;

    await updateCube(req.params.id, accessoryId);

    res.redirect("/details/" + req.params.id);
})

router.get("/search", async (req, res) => {
    const {keyword, from, to} = req.query;

    res.render("index", {
        title: "searchResults",
        cubes: await getCubesByCriteria(keyword, from, to),
    });
})

router.get("*", (req, res) => {
    res.render("404", {
        title: "Page Not Found",
    })
})

module.exports = router;