const Shoe = require("../models/shoe.js");
const User = require("../models/user.js");

const createShoe = async (data, creator) => {
    const createdAt = Date.now();
    Object.assign(data, {creator, createdAt});

    const shoe = new Shoe(data);
    await shoe.save();
}


const getAllShoes = async () => {
    return Shoe.find({});
}

const getShoeData = async (shoeId) => {
    return Shoe.findById(shoeId);
}

const buyShoe = async (shoeId, buyerId) => {
    await Shoe.findById(shoeId).lean(false).update({
        $addToSet: {
            buyers: [buyerId]
        }
    })

    await User.findById(buyerId).lean(false).update({
        $addToSet: {
            purchases: [shoeId]
        }
    })
}

const editShoe = async (shoeId, args) => {
    await Shoe.findById(shoeId).update(args);
}

const deleteShoe = async (shoeId) => {
    await Shoe.findByIdAndDelete(shoeId);
}

module.exports = {
    createShoe,
    getAllShoes,
    getShoeData,
    buyShoe,
    editShoe,
    deleteShoe
}