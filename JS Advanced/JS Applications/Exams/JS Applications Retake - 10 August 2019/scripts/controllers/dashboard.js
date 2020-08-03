import {getAllCauses} from "./data.js";
import {toggleLoading} from "../notifications.js";

export default async function () {
    const causes = await getAllCauses();
    const context = Object.assign({}, this.app.userData);
    context.causes = causes;

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/dashboard/dashboard.hbs', context)
        .then(() => toggleLoading(false));
}