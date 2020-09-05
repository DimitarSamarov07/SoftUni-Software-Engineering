const env = process.env.NODE_ENV || 'development';

const mongoose = require('mongoose');
const config = require('./config/config')[env];
const app = require('express')();

mongoose.connect(config.databaseUrl, {useNewUrlParser: true, useUnifiedTopology: true}, (err) => {
    if (err) {
        console.log(err);
        throw err;
    }

    console.log("Database initialized successfully.");
})
require('./config/express')(app);
app.use("/", require("./routes"));

app.listen(config.port, console.log(`Listening on port ${config.port}! Now its up to you...`));