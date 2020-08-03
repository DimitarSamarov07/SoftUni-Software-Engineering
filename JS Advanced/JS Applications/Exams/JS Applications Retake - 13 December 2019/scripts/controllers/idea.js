import {toggleError, toggleInfo, toggleLoading} from "../notifications.js";
import {commentOnIdea, createIdea, deleteIdea, getIdeaById, like} from "../data.js";

export async function createIdeaGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/create/createPage.hbs', this.app.userData)
        .then(() => {
            $("#createForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => toggleLoading(false));
}

export async function createIdeaPost() {
    const {title, description, imageUrl} = this.params;

    if (title.length < 6) {
        toggleLoading(false);
        toggleError(true, "Title should be at least 6 characters long.");
        return;
    }

    if (description.length < 10) {
        toggleLoading(false);
        toggleError(true, "Description should be at least 10 characters long.");
        return;
    }

    if (!imageUrl.startsWith("http://") && !imageUrl.startsWith("https://")) {
        toggleLoading(false);
        toggleError(true, "The image url should be in valid format.");
        return;
    }

    Backendless.UserService.getCurrentUser()
        .then(async ({objectId: userId}) => {
            await createIdea(userId, title, description, imageUrl)
                .then(() => {
                    toggleLoading(false);
                    toggleInfo(true, "Idea created successfully.")
                    setTimeout(function () {
                        this.redirect("#/dashboard")
                    }.bind(this), 1000)
                });
        })
}

export async function commentOnIdeaPost() {
    const {ideaId, content} = this.params;
    await commentOnIdea(ideaId, this.app.userData.username, content)
        .then(() => {
            toggleLoading(false);
            toggleInfo(true, "Comment uploaded successfully.")

            setTimeout(function () {
                this.redirect("#/details/" + ideaId)
            }.bind(this), 100)
        })
}

export async function likeIdeaGet() {
    const {ideaId} = this.params;
    await like(ideaId)
        .then(() => {
            toggleLoading(false);
            toggleInfo(true, "You liked the idea successfully.")

            setTimeout(function () {
                this.redirect("#/details/" + ideaId);
            }.bind(this), 500)
        })
}

export async function deleteIdeaGet() {
    const {ideaId} = this.params;
    await deleteIdea(ideaId)
        .then(() => {
            toggleLoading(false);
            toggleInfo(true, "Idea deleted successfully.")

            setTimeout(function () {
                this.redirect("#/dashboard");
            }.bind(this), 1000)
        })
}

export async function ideaDetailsGet() {
    const {ideaId} = this.params;
    const idea = await getIdeaById(ideaId);
    const isAuthor = this.app.userData.userId === idea.authorId;
    const context = Object.assign({}, idea, this.app.userData);
    context.isAuthor = isAuthor;

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/details/detailsPage.hbs', context)
        .then(() => {
            $("#commentForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => toggleLoading(false));
}