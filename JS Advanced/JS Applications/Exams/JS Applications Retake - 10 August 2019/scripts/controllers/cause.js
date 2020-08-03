import {toggleError, toggleInfo, toggleLoading} from "../notifications.js";
import {createCause, donateToCause, getCauseById} from "./data.js";

export async function createCauseGet() {
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

export async function createCausePost() {
    const {title, description, fundsGoal, imageUrl} = this.params;

    if (!title || !description || !fundsGoal || !imageUrl) {
        toggleError(true, "All fields must be filled.")
        return;
    }

    await createCause(this.app.userData.userId, title, description, fundsGoal, imageUrl);
    toggleLoading(false);
    toggleInfo(true, "Cause created successfully.")
    setTimeout(function () {
        this.redirect("#/");
    }.bind(this), 1000)
}

export async function causeDetailsGet() {
    const {causeId} = this.params;
    const cause = await getCauseById(causeId);
    cause.isAuthor = cause.authorId === this.app.userData.userId;

    const context = Object.assign({}, this.app.userData, cause);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial("./templates/details/detailsPage.hbs", context)
        .then(() => {
            $("#donateForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => toggleLoading(false));
}

export async function donateToCausePost() {
    const {causeId, amount} = this.params;
    await donateToCause(causeId, this.app.userData.username, amount);
    toggleLoading(false);
    setTimeout(function () {
        this.redirect("#/details/" + causeId)
    }.bind(this), 1000)
}