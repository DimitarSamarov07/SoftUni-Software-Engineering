function solution() {
    const ingredients = {
        "protein": 0,
        "carbohydrate": 0,
        "fat": 0,
        "flavour": 0,
    }

    return doYourJob;

    function doYourJob(inputStr) {

        let [command, firstParam, secondParam] = inputStr.split(" ");

        secondParam = Number(secondParam)

        if (command === "restock") {
            return restock(firstParam, secondParam);
        } else if (command === "prepare") {
            return prepare(firstParam, secondParam);
        } else if (command === "report") {
            return report();
        }

        function report() {
            return `protein=${ingredients["protein"]} carbohydrate=${ingredients["carbohydrate"]} fat=${ingredients["fat"]} flavour=${ingredients["flavour"]}`
        }

        function restock(ingredient, quantity) {
            ingredients[ingredient] += quantity;
            return "Success"
        }

        function prepare(recipe, quantity) {
            let message = "";
            const carbohydrateErrorMsg = "Error: not enough carbohydrate in stock";
            const flavourErrorMsg = "Error: not enough flavour in stock";
            const fatErrorMsg = "Error: not enough fat in stock";
            const proteinErrorMsg = "Error: not enough protein in stock";

            switch (recipe) {
                case "apple":
                    if (ingredients['carbohydrate'] < quantity) {
                        message = carbohydrateErrorMsg
                    } else if (ingredients["flavour"] < quantity * 2) {
                        message = flavourErrorMsg
                    }

                    if (!message) {
                        ingredients["flavour"] -= quantity * 2;
                        ingredients["carbohydrate"] -= quantity;
                        return "Success"
                    }
                    return message;

                case "lemonade":

                    if (ingredients['carbohydrate'] < quantity * 10) {
                        message = carbohydrateErrorMsg;
                    } else if (ingredients["flavour"] < quantity * 20) {
                        message = flavourErrorMsg;
                    }

                    if (!message) {
                        ingredients["flavour"] -= quantity * 20;
                        ingredients["carbohydrate"] -= quantity * 10;
                        return "Success"
                    }
                    return message;

                case "burger":
                    if (ingredients['carbohydrate'] < quantity * 5) {
                        message = carbohydrateErrorMsg;
                    } else if (ingredients["fat"] < quantity * 7) {
                        message = fatErrorMsg;
                    } else if (ingredients["flavour"] < quantity * 3) {
                        message = flavourErrorMsg;
                    }

                    if (!message) {
                        ingredients["flavour"] -= quantity * 3;
                        ingredients["carbohydrate"] -= quantity * 5;
                        ingredients["fat"] -= quantity * 7;
                        return "Success"
                    }
                    return message;

                case "eggs":
                    if (ingredients['protein'] < quantity * 5) {
                        message = proteinErrorMsg;
                    } else if (ingredients["fat"] < quantity) {
                        message = fatErrorMsg;
                    } else if (ingredients["flavour"] < quantity) {
                        message = flavourErrorMsg;
                    }

                    if (!message) {
                        ingredients["flavour"] -= quantity;
                        ingredients["protein"] -= quantity * 5;
                        ingredients["fat"] -= quantity;
                        return "Success"
                    }
                    return message;

                case "turkey":
                    if (ingredients['protein'] < quantity * 10) {
                        message = proteinErrorMsg;
                    } else if (ingredients["carbohydrate"] < quantity * 10) {
                        message = carbohydrateErrorMsg;
                    } else if (ingredients["fat"] < quantity * 10) {
                        message = fatErrorMsg;
                    } else if (ingredients["flavour"] < quantity * 10) {
                        message = flavourErrorMsg;
                    }

                    if (!message) {
                        ingredients["flavour"] -= quantity * 10;
                        ingredients["protein"] -= quantity * 10;
                        ingredients["fat"] -= quantity * 10;
                        ingredients["carbohydrate"] -= quantity * 10;
                        return "Success"
                    }
                    return message;
            }

            return message;
        }
    }

}