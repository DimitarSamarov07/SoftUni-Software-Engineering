const {checkIfAuthenticated, decodeJwt, handleAuthenticated} = require("../controllers/auth.js");
const {createPlay, getPlayById, updatePlayById, deletePlayById, likePlayById, handleCreator} = require("../controllers/plays.js");

const express = require("express");
const router = express.Router();

router.get("/create", handleAuthenticated, async (req, res) => {

    return res.render("create-play", {
        isAuthenticated: await checkIfAuthenticated(req)
    })
})

router.post("/create", handleAuthenticated, async (req, res) => {
    if (Object.values(req.body).some(x => !x)) {
        return res.render("create-play", {
            isAuthenticated: await checkIfAuthenticated(req),
            error: "All fields are required.",
            ...req.body
        })
    }

    const checkSwitch = {
        on: true,
        undefined: false,
    }
    req.body.isPublic = checkSwitch[req.body.isPublic];
    const token = await decodeJwt(req.cookies["aid"]);
    req.body.creatorId = token.userID

    await createPlay(req.body);
    return res.redirect("/");
})

router.get("/details/:id", handleAuthenticated, async (req, res) => {
    const {userID} = await decodeJwt(req.cookies["aid"])
    const play = await getPlayById(req.params.id);

    return res.render("play-details", {
        isAuthenticated: await checkIfAuthenticated(req),
        isCreator: play.creatorId.toString() === userID,
        hasLiked: play.usersLiked.map(x => x.toString()).includes(userID),
        ...play,
    })
})

router.get("/edit/:id", handleAuthenticated, handleCreator, async (req, res) => {
    const play = await getPlayById(req.params.id);

    return res.render("edit-play", {
        isAuthenticated: await checkIfAuthenticated(req),
        ...play
    })
})

router.post("/edit/:id", handleAuthenticated, handleCreator, async (req, res) => {
    const checkSwitch = {
        on: true,
        undefined: false,
    }
    req.body.isPublic = checkSwitch[req.body.isPublic];

    await updatePlayById(req.params.id, req.body);

    return res.redirect("/details/" + req.params.id);
})

router.get("/delete/:id", handleAuthenticated, handleCreator, async (req, res) => {
    await deletePlayById(req.params.id);

    return res.redirect("/");
})

router.get("/like/:id", handleAuthenticated, async (req, res) => {
    const {userID} = await decodeJwt(req.cookies["aid"]);

    await likePlayById(req.params.id, userID);

    return res.redirect("/");
})


module.exports = router;