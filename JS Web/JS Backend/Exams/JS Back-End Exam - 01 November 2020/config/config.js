module.exports = {
    development: {
        port: process.env.PORT || 5000,
        databaseUrl: `mongodb+srv://root:samarov2007@cluster0.xxd0m.azure.mongodb.net/tutorials?retryWrites=true&w=majority`
    },
    production: {}
};