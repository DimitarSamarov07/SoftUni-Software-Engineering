import {toggleLoading} from "../notifications.js";
import {getAllRecipes} from "./data.js";

export default async function () {
    const context = {}
    if (this.app.userData.loggedIn) {
        const categoryImageMap = {
            "Vegetables and legumes/beans": "https://cdn.pixabay.com/photo/2017/10/09/19/29/eat-2834549__340.jpg",
            "Fruits": "https://cdn.pixabay.com/photo/2017/06/02/18/24/fruit-2367029__340.jpg",
            "Grain Food": "https://cdn.pixabay.com/photo/2014/12/11/02/55/corn-syrup-563796__340.jpg",
            "Milk, cheese, eggs and alternatives": "https://image.shutterstock.com/image-photo/assorted-dairy-products-milk-yogurt-260nw-530162824.jpg",
            "Lean meats and poultry, fish and alternatives": "https://t3.ftcdn.net/jpg/01/18/84/52/240_F_118845283_n9uWnb81tg8cG7Rf9y3McWT1DT1ZKTDx.jpg",
        }

        context.recipes = await getAllRecipes();
        context.recipes.forEach((recipe) => {
            recipe.categoryImageUrl = categoryImageMap[recipe.category];
        })
    }
    Object.assign(context, this.app.userData);
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loggedInHome: await this.load('./templates/home/loggedInHome.hbs'),
        guestHome: await this.load('./templates/home/guestHome.hbs')
    };

    this.partial('./templates/home/homePage.hbs', context)
        .then(() => toggleLoading(false));
}