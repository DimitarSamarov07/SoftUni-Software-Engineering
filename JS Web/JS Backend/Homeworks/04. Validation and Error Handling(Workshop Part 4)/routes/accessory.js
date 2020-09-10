const {handleAuthenticated, checkIfAuthenticated, errorFormatter} = require("../controllers/users.js");
const {getCubeById, updateCube} = require("../controllers/cubes.js");
const {getAccessories} = require("../controllers/accessories.js");

const express = require("express");
const Accessory = require("../models/accessory.js");

const router = express.Router();
router.get("/create/accessory", handleAuthenticated, async (req, res) => {
    res.render("createAccessory", {
        title: "Create accessory",
        isAuthenticated: await checkIfAuthenticated(req, res)
    })
})

router.post("/create/accessory", handleAuthenticated, async (req, res) => {
    const accessory = new Accessory({...req.body});
    await accessory.save(async (err) => {
        debugger;
        if (err) {
            return res.render("createAccessory", {
                title: "Create accessory",
                isAuthenticated: await checkIfAuthenticated(req, res),
                error: errorFormatter(err),
            })
        }

        res.redirect("/");
    })
})

router.get("/attach/accessory/:id", handleAuthenticated, async (req, res) => {
    const cube = await getCubeById(req.params.id);

    let accessories = await getAccessories();
    const notAttachedAccessories = accessories.filter(accessory => cube.accessories.every(x => x._id.toString() !== accessory._id.toString()));

    res.render("attachAccessory", {
        title: "Attach accessory",
        ...cube,
        accessories: notAttachedAccessories,
        areAllAccessoriesEquipped: cube.accessories.length === accessories.length,
        isAuthenticated: await checkIfAuthenticated(req, res)
    })
})

router.post("/attach/accessory/:id", handleAuthenticated, async (req, res) => {
    const {accessoryId} = req.body;

    const error = await updateCube(req.params.id, accessoryId);
    if (error) {
        return res.redirect("/404")
    }

    res.redirect("/details/" + req.params.id);
})

module.exports = router;