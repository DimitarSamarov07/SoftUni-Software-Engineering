const User = require("../models/user.js");
const bcrypt = require('bcrypt');
const jwt = require("jsonwebtoken");

const privateKey = "There-is-no-end-only-new-beginnings-:)"

const getUserByEmail = async (email) => {
    return User.findOne({email})
}

const getCurrentUserEmail = async (token) => {
    const user = await decodeJwt(token);
    return user.email;
}

const saveUser = async (email, password) => {

    //hashing
    const salt = await bcrypt.genSalt(10);

    const hashedPassword = await bcrypt.hash(password, salt);

    const user = new User({
        email,
        password: hashedPassword
    })

    const userObj = await user.save();
    return signJwt(userObj._id, userObj.email);


}

const verifyUserPassword = async (email, password) => {
    const user = await getUserByEmail(email);

    if (!user) return false;

    const {password: hashedPassword} = user;

    const status = await bcrypt.compare(password, hashedPassword);
    return status ? signJwt(user._id, user.email) : false;
}

const signJwt = async (userID, email) => {
    return jwt.sign({
        userID,
        email
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

const validateEmail = (email) => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
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
    handleGuest,
    getCurrentUserEmail,
    validateEmail
}