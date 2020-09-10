const {getCubeById, getCubeWithAccessories, editCubeById, deleteCubeById, checkIfUserIsCreator, verifyId} = require("../controllers/cubes.js");
const {handleAuthenticated, errorFormatter} = require("../controllers/users.js");
const {decodeJwt, checkIfAuthenticated} = require("../controllers/users.js");

const express = require("express");
const Cube = require("../models/cube.js");

const router = express.Router();

router.get("/create", handleAuthenticated, async (req, res) => {
    res.render("create", {
        title: "Create Cube Page",
        isAuthenticated: await checkIfAuthenticated(req, res)
    });
})

router.post("/create", handleAuthenticated, async (req, res) => {
    const decodedToken = await decodeJwt(req.cookies["aid"]);

    if (!decodedToken) {
        res.redirect("/create");
        return;
    }

    const {userID: creatorId} = decodedToken;

    Object.keys(req.body).map(k => req.body[k] = req.body[k].trim());
    const {
        name,
        description,
        imageUrl,
        difficultyLevel
    } = req.body;

    const cube = new Cube({name, description, imageUrl, difficulty: Number(difficultyLevel), creatorId});
    await cube.save(err => {
        if (err) {
            return res.render("create", {
                title: "Create page",
                error: errorFormatter(err)
            });
        }

        res.redirect("/");
    });
})

router.get("/details/:id", async (req, res) => {
    if (!await verifyId(req.params.id)) {
        return res.status(404).redirect("/404");

    }

    const user = await decodeJwt(req.cookies["aid"]);
    const cube = await getCubeWithAccessories(req.params.id);

    if (!cube) {
        return res.status(404).redirect("/404");
    }

    return res.render("details", {
        title: "Cubicle",
        ...cube,
        isAuthenticated: await checkIfAuthenticated(req, res),
        isCreator: await checkIfUserIsCreator(req.params.id, user.userID)
    });


})

router.get("/edit/:id", handleAuthenticated, async (req, res) => {
    if (!await verifyId(req.params.id)) {
        return res.status(404).redirect("/404");

    }

    const cube = await getCubeById(req.params.id);
    if (!cube) {
        return res.status(404).redirect("/404");
    }

    await res.render("editCube", {
        ...cube,
        isAuthenticated: await checkIfAuthenticated(req, res)
    })

})

router.post("/edit/:id", handleAuthenticated, async (req, res) => {
    const user = await decodeJwt(req.cookies["aid"]);
    req.body.creatorId = user.userID;

    const result = await editCubeById(req.params.id, req.body);
    if (result) {
        console.log(result)
        const cube = await getCubeById(req.params.id)
        return res.render("editCube", {
            ...cube,
            error: result,
            isAuthenticated: await checkIfAuthenticated(req, res),
        })
    }

    res.redirect("/details/" + req.params.id)
})

router.get("/delete/:id", handleAuthenticated, async (req, res) => {
    if (!await verifyId(req.params.id)) {
        return res.status(404).redirect("/404");
    }

    const cube = await getCubeById(req.params.id);

    if (!cube) {
        return res.status(404).redirect("/404");
    }

    await res.render("deleteCube", {
        ...cube,
        isAuthenticated: await checkIfAuthenticated(req, res)
    })
})

router.post("/delete/:id", handleAuthenticated, async (req, res) => {
    const user = await decodeJwt(req.cookies["aid"]);

    await deleteCubeById(req.params.id, user.userID);
    res.redirect("/")
})

module.exports = router;