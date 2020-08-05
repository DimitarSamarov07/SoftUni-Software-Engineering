import {createEvent, deleteEvent, editEvent, getEventById, joinEvent} from "../data.js";
import {toggleInfo, toggleLoading} from "../notifications.js";
import {validateEventData} from "../validator.js";

export async function createEventGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial('./templates/create/createPage.hbs', this.app.userData)
        .then(() => {
            $("#createForm").submit((e) => {
                e.preventDefault();
            })
        })
        .then(() => toggleLoading(false));
}

export async function createEventPost() {
    if (await validateEventData(this.params)) {
        this.params.organizerName = this.app.userData.username;

        await createEvent(this.app.userData.userId, this.params);
        toggleLoading(false);
        toggleInfo(true, "Event created successfully.")
        this.redirect("#/")
    }
}

export async function eventDetailsGet() {
    const event = await getEventById(this.params.eventId);

    const context = Object.assign(event, this.app.userData)
    context.isAuthor = this.app.userData.userId === event.authorId;

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial("./templates/details/detailsPage.hbs", context)
        .then(() => toggleLoading(false));
}

export async function joinEventGet() {
    const {eventId} = this.params;
    await joinEvent(eventId);

    toggleInfo(true, "You joined the event successfully.");
    toggleLoading(false);
    this.redirect("#/details/" + eventId)
}

export async function editEventGet() {
    const {eventId} = this.params;
    const event = await getEventById(eventId);

    const context = Object.assign({}, event, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial('./templates/edit/editPage.hbs', context)
        .then(() => {
            $("#editForm").submit((e) => {
                e.preventDefault();
            })
        })
        .then(() => toggleLoading(false));
}

export async function editEventPost() {
    const {eventId} = this.params
    if (await validateEventData(this.params)) {
        delete this.params.eventId;

        await editEvent(eventId, this.params);
        toggleLoading(false);
        toggleInfo(true, "Event created successfully.")
        this.redirect("#/")
    }
}

export async function deleteEventGet() {
    const {eventId} = this.params;

    await deleteEvent(eventId);
    toggleInfo(true, "Event closed successfully.");
    toggleLoading(false);

    this.redirect("#/")
}