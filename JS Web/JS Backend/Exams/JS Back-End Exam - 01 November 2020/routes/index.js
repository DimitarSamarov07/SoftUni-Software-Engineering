const {checkIfAuthenticated, getCurrentUserUsernameFromRequest} = require("../controllers/auth.js");
const {getAllCourses} = require("../controllers/course.js");

const express = require("express");
const router = express.Router();
const moment = require('moment');

router.get("/", async (req, res) => {
    debugger;
    let courses = await getAllCourses();
    const authenticated = await checkIfAuthenticated(req);
    if (courses) {
        courses.forEach(x => x.parsedDate = moment(x.createdAt).format("ddd MMM DD HH:mm:ss"))
        courses = courses.sort((a, b) => b.usersEnrolled.length - a.usersEnrolled.length);
    }

    if (!authenticated && courses) {
        courses = courses.slice(0, 3)
    }

    return res.render("home", {
        isAuthenticated: await checkIfAuthenticated(req),
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        courses
    });
})

router.get("/search", async (req, res) => {
    debugger;
    const query = req.query.queryString;
    let courses = await getAllCourses();
    courses = courses.filter(x => x.title.toLowerCase().includes(query.toLowerCase()));

    return res.render("home", {
        isAuthenticated: await checkIfAuthenticated(req),
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        courses
    })
})

module.exports = router;