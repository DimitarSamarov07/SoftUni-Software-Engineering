const Trip = require("../models/trip.js");

const createTrip = async (args) => {
    const trip = new Trip(args);

    return trip.save();
}

const getAllTrips = async () => {
    return Trip.find({});
}

const getFullTripDataById = async (id) => {
    return Trip.findById(id).populate("buddies").populate("creator");
}

const getTripById = async (id) => {
    return Trip.findById(id)
}

const joinTrip = async (tripId, userId) => {
    await Trip.find({_id: tripId}).lean(false).where("creator").ne(userId).update({
        $addToSet: {
            buddies: [userId]
        },
    })
}

const deleteTripById = async (tripId) => {
    await Trip.findByIdAndDelete(tripId);
}

module.exports = {
    createTrip,
    getAllTrips,
    getTripById,
    getFullTripDataById,
    joinTrip,
    deleteTripById
}