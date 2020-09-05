const Cube = require("../models/cube.js");

const getAllCubes = async () => {
    return Cube.find({}).lean();
}

const getCubeById = async (id) => {
    return Cube.findById(id).lean();
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
        .lte((difficultyTo))
        .lean();
}

const updateCube = async (cubeId, accessoryId) => {
    await Cube.findByIdAndUpdate(cubeId, {
        $addToSet: {
            accessories: [accessoryId]
        }
    })
}

const getCubeAccessories = async (id) => {
    return Cube.findById(id).populate("accessories").lean();
}


module.exports = {
    getAllCubes,
    getCubeById,
    getCubesByCriteria,
    updateCube,
    getCubeWithAccessories: getCubeAccessories
}