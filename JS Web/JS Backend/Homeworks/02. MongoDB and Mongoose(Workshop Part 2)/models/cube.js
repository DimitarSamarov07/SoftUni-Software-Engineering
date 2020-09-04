// • Id - number(uuid)
//     • Name – string
//     • Description – string
//     • Image URL – string
//     • Difficulty Level– number
const {v4} = require("uuid")
const fs = require("fs")

class Cube {
    constructor(name, description, imageURL, difficulty) {
        this.id = v4();
        this.name = name;
        this.description = description;
        this.imageURL = imageURL;
        this.difficulty = difficulty;
    }

    save() {
        const dbFile = "./config/database.json";

        fs.readFile(dbFile, (err, data) => {
            if (err) {
                throw err;
            }

            const cubes = JSON.parse(data);
            cubes.push(this);

            fs.writeFile(dbFile, JSON.stringify(cubes), (err) => {
                if (err) {
                    throw err;
                }
            })
        });


        console.log("New cube is successfully stored")
    }
}

module.exports = Cube;