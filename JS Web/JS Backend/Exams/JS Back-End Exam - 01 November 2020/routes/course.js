const {handleAuthenticated, checkIfAuthenticated, getCurrentUserUsernameFromRequest, getCurrentUserIdFromRequest} = require("../controllers/auth.js");
const {createCourse, getCourseById, editCourseById, deleteCourseById, enrollUser} = require("../controllers/course.js");
const {validateCourseData} = require("../controllers/validator.js");

const express = require("express");
const router = express.Router();


router.get("/create", handleAuthenticated, async (req, res) => {
    return res.render("create-course", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        isAuthenticated: await checkIfAuthenticated(req),
    })
})

router.post("/create", handleAuthenticated, async (req, res) => {
    const data = req.body;
    const userId = await getCurrentUserIdFromRequest(req);

    const error = await validateCourseData(data);
    if (error) {
        return res.render("create-course", {
            loggedInUsername: await getCurrentUserUsernameFromRequest(req),
            isAuthenticated: await checkIfAuthenticated(req),
            error,
            ...data
        })
    }

    await createCourse(data, userId);

    return res.redirect("/")
})

router.get("/details/:id", handleAuthenticated, async (req, res) => {
    const course = await getCourseById(req.params.id);
    const userId = await getCurrentUserIdFromRequest(req);
    const isCreator = course.creator.toString() === userId;
    let isEnrolled;

    if (isCreator) isEnrolled = false;
    else isEnrolled = !!course.usersEnrolled.find(x => x.toString() === userId);


    return res.render("course-details", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        isAuthenticated: await checkIfAuthenticated(req),
        isEnrolled,
        isCreator,
        ...course,
    })
})

router.get("/edit/:id", handleAuthenticated, async (req, res) => {
    const courseData = await getCourseById(req.params.id);

    const userId = await getCurrentUserIdFromRequest(req);

    if (courseData.creator.toString() !== userId) {
        return res.redirect("/")
    }

    return res.render("edit-course", {
        loggedInUsername: await getCurrentUserUsernameFromRequest(req),
        isAuthenticated: await checkIfAuthenticated(req),
        ...courseData
    })
})

router.post("/edit/:id", handleAuthenticated, async (req, res) => {
    const data = req.body;
    const id = req.params.id;

    const courseData = await getCourseById(id);
    const userId = await getCurrentUserIdFromRequest(req);

    if (courseData.creator.toString() !== userId) {
        return res.redirect("/")
    }

    const error = await validateCourseData(data);
    if (error) {
        return res.render("create-course", {
            loggedInUsername: await getCurrentUserUsernameFromRequest(req),
            isAuthenticated: await checkIfAuthenticated(req),
            error,
            ...data
        })
    }
    await editCourseById(id, data);

    return res.redirect("/")
})

router.get("/delete/:id", handleAuthenticated, async (req, res) => {
    const id = req.params.id;
    const courseData = await getCourseById(id);
    const userId = await getCurrentUserIdFromRequest(req);

    if (courseData.creator.toString() !== userId) {
        return res.redirect("/")
    }

    await deleteCourseById(id);

    return res.redirect("/");
})

router.get("/enroll/:id", handleAuthenticated, async (req, res) => {
    const courseId = req.params.id;
    const courseData = await getCourseById(courseId);
    const userId = await getCurrentUserIdFromRequest(req);

    if (courseData.usersEnrolled.some(x => x.toString() === userId) || courseData.creator.toString() === userId) {
        return res.redirect("/")
    }

    await enrollUser(courseId, userId);

    return res.redirect("/")
})

module.exports = router;