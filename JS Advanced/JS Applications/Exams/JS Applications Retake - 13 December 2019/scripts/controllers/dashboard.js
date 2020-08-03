import {toggleLoading} from "../notifications.js";
import {getAllIdeas} from "../data.js";

export default async function () {
    let ideas = await getAllIdeas();

    ideas = ideas.sort((a, b) => b.likesCount - a.likesCount)

    const context = Object.assign({}, this.app.userData);
    context.ideas = ideas;
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/dashboard/dashboardPage.hbs', context)
        .then(() => toggleLoading(false));
}