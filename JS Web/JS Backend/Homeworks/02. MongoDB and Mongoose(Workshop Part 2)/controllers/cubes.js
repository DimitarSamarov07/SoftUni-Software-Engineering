const fs = require("fs")

const getAllCubes = () => {
    const cubes = fs.readFileSync("./config/database.json");

    return JSON.parse(cubes);
}

const getCubeById = (id) => {
    const cubes = getAllCubes();

    return cubes.find(x => x.id === id)
}

const getCubesByCriteria = (keyword, difficultyFrom, difficultyTo) => {
    const cubes = getAllCubes();

    if (!difficultyFrom || !difficultyTo || isNaN(difficultyFrom) || isNaN(difficultyTo)) {
        difficultyFrom = 1;
        difficultyTo = Number.MAX_SAFE_INTEGER
    }
    return cubes.filter(x => x.name.includes(keyword) && x.difficulty >= Number(difficultyFrom) && x.difficulty <= Number(difficultyTo));
}

module.exports = {
    getAllCubes,
    getCubeById,
    getCubesByCriteria
}