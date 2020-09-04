const Cube = require("../models/cube.js");

const newCube = new Cube("Default", "default cube", "google.com", 1);
newCube.save();