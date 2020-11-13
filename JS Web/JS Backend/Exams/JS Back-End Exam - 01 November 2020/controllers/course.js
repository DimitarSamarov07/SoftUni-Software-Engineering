const Course = require("../models/course.js");
const User = require("../models/user.js");

const moment = require("moment");

const getAllCourses = async () => {
    return Course.find({});
}

const createCourse = async (args, creator) => {
    const createdAt = moment().toDate();

    Object.assign(args, {creator, createdAt})
    const course = new Course(args);
    await course.save();
}

const getCourseById = async (id) => {
    return Course.findById(id);
}

const deleteCourseById = async (id) => {
    await Course.findByIdAndDelete(id);
}

const editCourseById = async (id, data) => {
    delete data.creator; //anti tamper
    await Course.findById(id).update(data);
}

const enrollUser = async (courseId, userId) => {
    await Course.findById(courseId).lean(false).update({
        $addToSet: {
            usersEnrolled: [userId]
        }
    })

    await User.findById(userId).lean(false).update({
        $addToSet: {
            courses: [courseId]
        }
    })
}

module.exports = {
    getAllCourses,
    createCourse,
    getCourseById,
    deleteCourseById,
    editCourseById,
    enrollUser
}