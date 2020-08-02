import {toggleError, toggleInfo, toggleLoading} from "../notifications.js";
import {closeTrek, createTrek, editTrek, getTrekById, getUserById, likeTrek} from "../data.js";

export async function createTrekGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial("./templates/create/createPage.hbs", this.app.userData)
        .then(() => {
            $("#createForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => toggleLoading(false));
}

export async function createTrekPost() {
    const {location, dateTime, description, imageUrl} = this.params;
    Backendless.UserService.getCurrentUser()
        .then(async (user) => {

            if (location.length < 6 || description.length < 10) {
                toggleError(true, "Invalid input")
                toggleLoading(false);
                return;
            }

            await createTrek(user.objectId, location, description, dateTime, imageUrl);
            toggleLoading(false);
            toggleInfo(true, "Trek created successfully")

            setTimeout(function () {
                this.redirect("#/create");
            }.bind(this), 1000)
        })
}

export async function trekDetailsGet() {
    const {trekId} = this.params;
    const trek = await getTrekById(trekId);
    const organizer = await getUserById(trek.organizerId);

    trek.organizer = organizer.username;
    trek.isOrganizer = trek.organizerId === this.app.userData.userId;

    const context = Object.assign({}, this.app.userData, trek)

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial("./templates/details/detailsPage.hbs", context)
        .then(() => toggleLoading(false));
}

export async function editTrekGet() {
    const {trekId} = this.params;

    const trek = await getTrekById(trekId);

    const context = Object.assign({}, trek, this.app.userData)

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial("./templates/edit/editPage.hbs", context)
        .then(() => {
            $("#editForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => toggleLoading(false));
}

export async function editTrekPost() {
    const {trekId, location, dateTime, description, imageUrl} = this.params;
    await editTrek(trekId, location, description, dateTime, imageUrl)
        .then(() => {
            toggleLoading(false);
            toggleInfo(true, "Trek edited successfully.")

            setTimeout(function () {
                this.redirect("#/")
            }.bind(this))
        })
}

export async function closeTrekGet() {
    const {trekId} = this.params;
    await closeTrek(trekId)
        .then(() => {
            toggleLoading(false);
            toggleInfo(true, "You closed the trek successfully.")
            setTimeout(function () {
                this.redirect("#/");
            }.bind(this), 1000)
        })
}

export async function likeGet() {
    const {trekId} = this.params;
    await likeTrek(trekId);
    toggleLoading(false);
    toggleInfo(true, "You liked the trek successfully.");
    setTimeout(function () {
        this.redirect("#/details/" + trekId);
    }.bind(this), 300)
}