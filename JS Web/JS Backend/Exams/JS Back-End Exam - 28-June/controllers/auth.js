const User = require("../models/user.js");
const bcrypt = require('bcrypt');
const jwt = require("jsonwebtoken");

const privateKey = "There-is-no-end-only-new-beginnings-:)"

const getUserByUsername = async (username) => {
    return User.findOne({username})
}

const saveUser = async (username, password) => {

    //hashing
    const salt = await bcrypt.genSalt(10);

    const hashedPassword = await bcrypt.hash(password, salt);

    const user = new User({
        username,
        password: hashedPassword
    })

    const userObj = await user.save();
    return signJwt(userObj._id, userObj.username);


}

const verifyUserPassword = async (username, password) => {
    const user = await getUserByUsername(username);

    if (!user) return false;

    const {password: hashedPassword} = user;

    const status = await bcrypt.compare(password, hashedPassword);
    return status ? signJwt(user._id, user.username) : false;
}

const signJwt = async (userID, username) => {
    return jwt.sign({
        userID,
        username
    }, privateKey, {algorithm: 'HS256'});
}

const decodeJwt = async (token) => {
    try {
        return jwt.verify(token, privateKey);
    } catch {
        return false
    }
}

const checkIfAuthenticated = async (req) => {
    const token = req.cookies["aid"];
    const status = await decodeJwt(token);

    return !!status
}

const handleAuthenticated = async (req, res, next) => {
    const status = await checkIfAuthenticated(req)
    if (!status) {
        res.redirect("/");
    } else {
        next();
    }
}

const handleGuest = async (req, res, next) => {
    const status = await checkIfAuthenticated(req)

    if (!status) {
        next();
    } else {
        res.redirect("/");
    }
}

module.exports = {
    saveUser,
    verifyUserPassword,
    decodeJwt,
    checkIfAuthenticated,
    handleAuthenticated,
    handleGuest
}