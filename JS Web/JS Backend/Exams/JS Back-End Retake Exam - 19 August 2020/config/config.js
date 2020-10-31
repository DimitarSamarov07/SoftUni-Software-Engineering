module.exports = {
    development: {
        port: process.env.PORT || 5000,
        databaseUrl: `mongodb+srv://${process.env.NODE_ENV_MONGO_USERNAME}:${process.env.NODE_ENV_MONGO_PASS}@cluster0.xxd0m.azure.mongodb.net/shoe-shelf?retryWrites=true&w=majority`
    },
    production: {}
};