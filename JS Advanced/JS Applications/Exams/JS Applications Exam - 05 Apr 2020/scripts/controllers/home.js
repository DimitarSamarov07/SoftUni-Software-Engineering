import {getAllArticles} from "../data.js";

export default async function () {
    let articles = await getAllArticles();

    const js = [];
    const csharp = [];
    const pyton = [];
    const java = [];

    const switcher = {
        "javascript": (article) => js.push(article),
        "c#": (article) => csharp.push(article),
        "pyton": (article) => pyton.push(article),
        "java": (article) => java.push(article)
    }

    articles.forEach((curr) => {
        switcher[curr.category.toLowerCase()](curr);
    })

    js.sort((a, b) => b.title.localeCompare(a.title));
    csharp.sort((a, b) => b.title.localeCompare(a.title));
    pyton.sort((a, b) => b.title.localeCompare(a.title));
    java.sort((a, b) => b.title.localeCompare(a.title));
    const context = {js, csharp, pyton, java};
    Object.assign(context, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loggedInHome: await this.load('./templates/home/loggedInHome.hbs'),
        loginPage: await this.load('./templates/login/loginPage.hbs'),
        loginForm: await this.load('./templates/login/loginForm.hbs'),
    };

    this.partial('./templates/home/homePage.hbs', context);
}