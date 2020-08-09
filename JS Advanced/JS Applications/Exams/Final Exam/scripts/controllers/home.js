import {allMovies} from "../data.js";

export default async function() {
    const context = {};
    if (this.app.userData.loggedIn){
        Object.assign(context, this.app.userData);
        context.movies = await allMovies();
    }
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loggedInHome: await this.load('./templates/home/loggedInHome.hbs'),
        guestHome: await this.load('./templates/home/guestHome.hbs')
    };

    this.partial('./templates/home/homePage.hbs', context)
}