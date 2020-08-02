import {toggleLoading} from "../notifications.js";
import {getAllTreks} from "../data.js";

export default async function () {
    const treks = await getAllTreks();

    const context = Object.assign({}, this.app.userData);
    context.treks = treks;

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loggedInHome: await this.load('./templates/home/loggedInHome.hbs'),
        guestHome: await this.load('./templates/home/guestHome.hbs'),
        treksList: await this.load('./templates/home/treksList.hbs'),
    };

    this.partial("./templates/home/homePage.hbs", context)
        .then(() => toggleLoading(false));
}