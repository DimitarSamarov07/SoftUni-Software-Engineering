const Accessory = require("../models/accessory.js");

const getAccessories = () => {
    return Accessory.find({}).lean();
}
module.exports = {
    getAccessories
}