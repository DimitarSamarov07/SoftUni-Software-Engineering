const {handleAuthenticated, getCurrentUserUsernameFromRequest, checkIfAuthenticated, decodeJwt} = require("../controllers/auth.js");
const {createShoe, getShoeData, buyShoe, editShoe, deleteShoe} = require("../controllers/shoes.js");

const express = require("express");
const router = express.Router();

router.get("/create", handleAuthenticated, async (req, res) => {
    const isAuthenticated = await checkIfAuthenticated(req);

    return res.render("create-offer", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        isAuthenticated,
    })
})

router.post("/create", handleAuthenticated, async (req, res) => {
    debugger;
    if (Array.from(req.body).some(x => !x)) {
        return res.reload();
    }

    const userId = await (await decodeJwt(req.cookies["aid"])).userID;

    await createShoe(req.body, userId)

    res.redirect("/");

})

router.get("/details/:id", handleAuthenticated, async (req, res) => {
    const shoeId = req.params.id;
    const data = await getShoeData(shoeId);

    const {userID} = await decodeJwt(req.cookies["aid"]);

    const isPurchased = data.buyers.some(x => x.toString() === userID);
    const buyersCount = data.buyers.length;
    const isCreator = data.creator.toString() === userID;

    return res.render("offer-details", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        isAuthenticated: await checkIfAuthenticated(req),
        ...data,
        isPurchased,
        buyersCount,
        isCreator
    })
})

router.get("/buy/:id", handleAuthenticated, async (req, res) => {
    debugger;
    const shoeId = req.params.id;
    const {userID} = await decodeJwt(req.cookies["aid"]);

    await buyShoe(shoeId, userID);

    return res.redirect("/details/" + shoeId)
})

router.get("/edit/:id", handleAuthenticated, async (req, res) => {
    const {id: shoeId} = req.params;
    const data = await getShoeData(shoeId);

    return res.render("edit-offer", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        isAuthenticated: await checkIfAuthenticated(req),
        ...data
    })
})

router.post("/edit/:id", handleAuthenticated, async (req, res) => {
    const {id: shoeId} = req.params;
    await editShoe(shoeId, req.body);

    return res.redirect("/details/" + shoeId);
})

router.get("/delete/:id", handleAuthenticated, async (req, res) => {
    const shoeId = req.params.id;
    await deleteShoe(shoeId);

    return res.redirect("/");
})

module.exports = router;