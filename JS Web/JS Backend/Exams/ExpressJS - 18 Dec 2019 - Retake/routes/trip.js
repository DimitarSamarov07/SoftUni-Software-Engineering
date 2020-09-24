const {handleAuthenticated, getCurrentUserEmail, decodeJwt} = require("../controllers/auth.js");
const {getAllTrips, createTrip, getTripById, getFullTripDataById, joinTrip, deleteTripById} = require("../controllers/trips.js");


const express = require("express");
const router = express.Router();

router.get("/trips", handleAuthenticated, async (req, res) => {
    const trips = await getAllTrips();
    return res.render("trips", {
        loggedInEmail: await getCurrentUserEmail(req.cookies["aid"]),
        isAuthenticated: true,
        trips
    })
})

router.get("/create", handleAuthenticated, async (req, res) => {
    return res.render("offerTripp", {
        loggedInEmail: await getCurrentUserEmail(req.cookies["aid"]),
        isAuthenticated: true
    })
})

router.post("/create", handleAuthenticated, async (req, res) => {
    const [startPoint, endPoint] = req.body["destination"].split(" - ");
    const [date, time] = req.body["dateTime"].split(" - ");

    let error;

    if (!startPoint || !endPoint) {
        error = `The start point and endpoint should be separated with single space, dash and another single space (" - ")`
    } else if (startPoint.length < 4 || endPoint.length < 4) {
        error = "Start and End point should be at least 4 characters long (each).";
    } else if (date.length < 6 || time.length < 6) {
        error = "Date and Time should be at least 6 characters long (each)."
    } else if (!req.body.carImageUrl.startsWith("http://") && !req.body.carImageUrl.startsWith("https://")) {
        error = "The car image should be a valid link."
    } else if (isNaN(req.body.seatsCount) || Number(req.body.seatsCount) <= 0) {
        error = "The seats count should be a positive number.";
    } else if (req.body.description.length < 10) {
        error = "The description should be at least 10 characters long.";
    }

    if (error) {
        return res.render("offerTripp", {
            error,
            ...req.body
        })
    }

    const {userID} = await decodeJwt(req.cookies["aid"])

    const data = Object.assign(req.body, {startPoint, endPoint, date, time, creator: userID});

    await createTrip(data);

    return res.redirect("/trips")
})

router.get("/details/:id", handleAuthenticated, async (req, res) => {
    const trip = await getFullTripDataById(req.params.id);
    const {userID, email} = await decodeJwt(req.cookies["aid"])

    const isDriver = trip.creator._id.toString() === userID;
    const capacityReached = trip.buddies.length + 1 > trip.seatsCount;
    const hasJoined = trip.buddies.some((x) => x._id.toString() === userID);
    const availableSeats = trip.seatsCount - trip.buddies.length;

    const driverEmail = trip.creator.email;
    const stringBuddies = trip.buddies.map(x => x.email).join(", ");

    return res.render("tripDetails", {
        isAuthenticated: true,
        ...trip,
        hasJoined,
        capacityReached,
        isDriver,
        loggedInEmail: email,
        availableSeats,
        driverEmail,
        stringBuddies
    })
})

router.get("/join/:id", handleAuthenticated, async (req, res) => {
    const tripId = req.params.id;

    const trip = await getTripById(tripId);
    const {userID} = await decodeJwt(req.cookies["aid"])

    if (trip.creator.toString() === userID) {
        return res.redirect("/");
    }

    await joinTrip(tripId, userID);

    return res.redirect("/details/" + tripId);

})

router.get("/close/:id", handleAuthenticated, async (req, res) => {
    const tripId = req.params.id;

    const trip = await getTripById(tripId);
    const {userID} = await decodeJwt(req.cookies["aid"])

    if (trip.creator.toString() !== userID) {
        return res.redirect("/");
    }

    await deleteTripById(tripId);

    return res.redirect("/trips");
})

module.exports = router;