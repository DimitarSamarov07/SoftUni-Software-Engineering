import {toggleLoading} from "../notifications.js";

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/home/homePage.hbs', this.app.userData)
        .then(() => toggleLoading(false));
}