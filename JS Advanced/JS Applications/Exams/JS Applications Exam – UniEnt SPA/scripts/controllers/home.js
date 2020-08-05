import {getAllEvents} from "../data.js";
import {toggleLoading} from "../notifications.js";

export default async function () {
    let context = {}
    if (this.app.userData.loggedIn) {
        context.events = await getAllEvents();
        context.events = context.events.sort(((a, b) => b.usersInterestedCount - a.usersInterestedCount));
    }
    Object.assign(context, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        guestHome: await this.load("./templates/home/guestHome.hbs"),
        loggedInHome: await this.load("./templates/home/loggedInHome.hbs")
    };

    this.partial('./templates/home/homePage.hbs', context)
        .then(() => toggleLoading(false));
}

