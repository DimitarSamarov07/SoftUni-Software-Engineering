const {getCubeById, updateCube} = require("../controllers/cubes.js");
const {getAccessories} = require("../controllers/accessories.js");
const {handleAuthenticated} = require("../controllers/users.js");
const {checkIfAuthenticated} = require("../controllers/users.js");

const express = require("express");
const Accessory = require("../models/accessory.js");

const router = express.Router();
router.get("/create/accessory", handleAuthenticated, async (req, res) => {
    res.render("createAccessory", {
        title: "Create accessory",
        isAuthenticated: await checkIfAuthenticated(req, res)
    })
})

router.post("/create/accessory", handleAuthenticated, (req, res) => {
    const accessory = new Accessory({...req.body});
    accessory.save((err) => {
        if (err) {
            console.log(err);
            throw err;
        }

        res.redirect("/");
    })
})

router.get("/attach/accessory/:id", handleAuthenticated, async (req, res) => {
    const cube = await getCubeById(req.params.id);

    debugger;
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

    await updateCube(req.params.id, accessoryId);

    res.redirect("/details/" + req.params.id);
})

module.exports = router;