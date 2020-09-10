const Cube = require("../models/cube.js");

const errorFormatter = (err) => {
    return err.message.slice(err.message.lastIndexOf(":") + 1, err.message.length)
}

const getAllCubes = async () => {
    return Cube.find({});
}

const getCubeById = async (id) => {
    if (!await verifyId(id)) {
        return;
    }
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
    if (!await verifyId(cubeId) || !await verifyId(accessoryId)) {
        return {};
    }

    await Cube.findByIdAndUpdate(cubeId, {
        $addToSet: {
            accessories: [accessoryId]
        },
    }, {runValidators: true})
}

const getCubeWithAccessories = async (id) => {
    if (!await verifyId(id)) {
        return;
    }
    return Cube.findById(id).populate("accessories");
}

const editCubeById = async (id, args) => {
    try {
        await Cube.updateOne({_id: id, creatorId: args.creatorId}, {...args}, {runValidators: true});
    } catch (err) {
        return errorFormatter(err);
    }
}

const verifyId = async (id) => {
    return !!id.match(/^[0-9a-fA-F]{24}$/);
}
const deleteCubeById = async (id, creatorId) => {
    if (!await verifyId(id)) {
        return;
    }
    await Cube.findOneAndDelete({_id: id, creatorId});
}

const checkIfUserIsCreator = async (cubeId, userId) => {
    const cube = await Cube.findOne({_id: cubeId, creatorId: userId});

    return !!cube;
}

module.exports = {
    getAllCubes,
    getCubeById,
    getCubesByCriteria,
    updateCube,
    getCubeWithAccessories,
    editCubeById,
    deleteCubeById,
    checkIfUserIsCreator,
    verifyId
}