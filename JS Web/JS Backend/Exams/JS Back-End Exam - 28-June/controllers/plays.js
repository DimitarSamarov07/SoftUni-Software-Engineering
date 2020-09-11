const Play = require("../models/play.js")
const {decodeJwt} = require("./auth.js");

const getAllPlays = async () => {
    return Play.find({isPublic: true});
}

const createPlay = async (args) => {
    const play = new Play(args);
    play.createdAt = Date.now();
    await play.save();
}

const getPlayById = async (id) => {
    return Play.findById(id);
}

const updatePlayById = async (id, args) => {
    await Play.findByIdAndUpdate(id, args)
}

const likePlayById = async (playId, userId) => {
    await Play.find({_id: playId}).lean(false).where("creatorId").ne(userId).update({
        $addToSet: {
            usersLiked: [userId]
        },
    })
}

const deletePlayById = async (id) => {
    await Play.findByIdAndDelete(id);
}

const handleCreator = async (req, res, next) => {
    const {userID} = await decodeJwt(req.cookies["aid"]);
    const result = await Play.find({creatorId: userID, _id: req.params.id});

    return result ? next() : res.redirect("/");
}

module.exports = {
    getAllPlays,
    createPlay,
    getPlayById,
    updatePlayById,
    deletePlayById,
    likePlayById,
    handleCreator
}