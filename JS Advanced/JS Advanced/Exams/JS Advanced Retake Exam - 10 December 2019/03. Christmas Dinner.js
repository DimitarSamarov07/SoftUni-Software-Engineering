class ChristmasDinner {
    constructor(budget) {
        this.budget = budget
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (value >= 0) {
            this._budget = value;
        } else {
            throw new Error("The budget cannot be a negative number");
        }
    }

    shopping([type, price]) {
        if (this.budget < price) {
            throw new Error("Not enough money to buy this product");
        }

        this.products.push(type);

        this.budget -= price;

        return `You have successfully bought ${type}!`
    }

    recipes({recipeName, productsList}) {
        if (productsList.every(x => this.products.includes(x))) {
            const recipe = {recipeName, productsList};
            this.dishes.push(recipe);

            return `${recipeName} has been successfully cooked!`;
        }
        //If we got here, at lease one of the products is missing
        throw new Error("We do not have this product")
    }

    inviteGuests(name, dish) {
        if (!this.dishes.find(x => x.recipeName === dish)) {
            throw new Error("We do not have this dish")
        }
        if (this.guests.hasOwnProperty(name)) {
            throw new Error("This guest has already been invited");
        }

        this.guests[name] = dish;

        return `You have successfully invited ${name}!`
    }

    showAttendance() {
        return Object.entries(this.guests).reduce((acc, [name, dishName]) => {
            const {productsList} = this.dishes.find(x => x.recipeName === dishName);

            acc += `${name} will eat ${dishName}, which consists of ${productsList.join(", ")}\n`

            return acc;
        }, "")
            .trim();

    }

}