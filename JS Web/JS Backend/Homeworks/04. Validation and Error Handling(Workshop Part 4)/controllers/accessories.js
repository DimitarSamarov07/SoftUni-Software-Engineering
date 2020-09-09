const Accessory = require("../models/accessory.js");

const getAccessories = () => {
    return Accessory.find({});
}
module.exports = {
    getAccessories
}