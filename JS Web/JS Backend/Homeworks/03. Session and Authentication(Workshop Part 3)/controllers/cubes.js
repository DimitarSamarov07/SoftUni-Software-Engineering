const Cube = require("../models/cube.js");

const getAllCubes = async () => {
    return Cube.find({});
}

const getCubeById = async (id) => {
    return Cube.findById(id);
}

const getCubesByCriteria = async (keyword, difficultyFrom, difficultyTo) => {

    if (!difficultyFrom || !difficultyTo || isNaN(difficultyFrom) || isNaN(difficultyTo)) {
        difficultyFrom = 1;
        difficultyTo = Number.MAX_SAFE_INTEGER
    } else {
        difficultyTo = Number(difficultyTo);
        difficultyFrom = Number(difficultyFrom);
    }
    return Cube.find({
        "name": {
            $regex: keyword,
            $options: "i"
        }
    }).where("difficulty").gte((difficultyFrom))
        .lte((difficultyTo));
}

const updateCube = async (cubeId, accessoryId) => {
    await Cube.findByIdAndUpdate(cubeId, {
        $addToSet: {
            accessories: [accessoryId]
        }
    })
}

const getCubeWithAccessories = async (id) => {
    return Cube.findById(id).populate("accessories");
}


module.exports = {
    getAllCubes,
    getCubeById,
    getCubesByCriteria,
    updateCube,
    getCubeWithAccessories
}