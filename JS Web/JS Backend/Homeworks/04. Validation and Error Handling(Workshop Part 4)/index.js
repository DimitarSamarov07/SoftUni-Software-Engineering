const env = process.env.NODE_ENV || 'development';

const mongoose = require('mongoose');
const config = require('../../Exams/JS Back-End Exam - 28-June/config/config')[env];
const app = require('express')();
const indexRouter = require("./routes/index.js")
const authRouter = require("../../Exams/JS Back-End Exam - 28-June/routes/auth.js")
const cubeRouter = require("./routes/cube.js");
const accessoryRouter = require("./routes/accessory.js");
const {checkIfAuthenticated} = require("./controllers/users.js");

let __setOptions = mongoose.Query.prototype.setOptions;

mongoose.Query.prototype.setOptions = function (options) {
    __setOptions.apply(this, arguments);
    if (this._mongooseOptions.lean == null) this._mongooseOptions.lean = true;
    return this;
};

mongoose.connect(config.databaseUrl, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
    useFindAndModify: false
}, (err) => {
    if (err) {
        console.log(err);
        throw err;
    }

    console.log("Database initialized successfully.");
})
require('../../Exams/JS Back-End Exam - 28-June/config/express')(app);

app.use("/", authRouter);
app.use("/", indexRouter);
app.use("/", cubeRouter);
app.use("/", accessoryRouter);

app.get("*", async (req, res) => {
    res.render("404", {
        title: "Page Not Found",
        isAuthenticated: await checkIfAuthenticated(req, res)
    })
})

app.listen(config.port, console.log(`Listening on port ${config.port}! Now its up to you...`));