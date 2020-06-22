class Bank {

    #transactions = {};

    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {

        const doesItExist = this.allCustomers.some(((x) => x.firstName === customer.firstName && x.lastName === customer.lastName));

        if (doesItExist) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney(personalId, amount) {
        const customer = this.allCustomers.find(x => x.personalId === personalId);

        if (!customer) {
            throw new Error("We have no customer with this ID!");
        }

        customer.hasOwnProperty("totalMoney") ? customer["totalMoney"] += amount : customer["totalMoney"] = amount;

        if (personalId in this.#transactions) {
            this.#transactions[personalId].push(amount);
        } else {
            this.#transactions[personalId] = [];
            this.#transactions[personalId].push(amount);
        }


        return customer.totalMoney + "$";
    }

    withdrawMoney(personalId, amount) {
        const customer = this.allCustomers.find(x => x.personalId === personalId);

        if (!customer) {
            throw new Error("We have no customer with this ID!");
        }

        if (customer.totalMoney - amount < 0) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`)
        }

        if (personalId in this.#transactions) {
            this.#transactions[personalId].push(-amount);
        } else {
            this.#transactions[personalId] = [];
            this.#transactions[personalId].push(-amount);
        }

        customer["totalMoney"] -= amount;

        return customer.totalMoney + "$";
    }

    customerInfo(personalId) {
        const customer = this.allCustomers.find(x => x.personalId === personalId);

        if (!customer) {
            throw new Error("We have no customer with this ID!");
        }

        const {firstName, lastName, totalMoney} = customer;

        let output = `Bank name: ${this._bankName}\n`;

        output += `Customer name: ${firstName} ${lastName}\n`;
        output += `Customer ID: ${personalId}\n`;
        output += `Total Money: ${totalMoney}$\n`;
        output += `Transactions:\n`

        output += this.#transactions[personalId].reduceRight((acc, amount, index) => {
            acc += amount > 0
                ? `${index + 1}. ${firstName} ${lastName} made deposit of ${amount}$!\n`
                : `${index + 1}. ${firstName} ${lastName} withdrew ${Math.abs(amount)}$!\n`;

            return acc;
        }, "")

        return output.trimEnd();
    }

}