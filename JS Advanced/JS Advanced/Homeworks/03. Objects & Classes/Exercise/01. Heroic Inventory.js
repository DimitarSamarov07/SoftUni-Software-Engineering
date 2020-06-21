function heroicInventory(inputArray = []) {

    let heroesArr = [];

    class Hero {
        constructor(name = '', level = 0, items = []) {
            this.name = name;
            this.level = level;
            this.items = items;
        }
    }

    for (let i = 0; i < inputArray.length; i++) {
        let [name, level, items] = inputArray[i].split(" / ");

        level = +level;
        items = items ? items.split(", ") : [];

        let hero = new Hero(name, level, items);
        heroesArr.push(hero);
    }

   console.log(JSON.stringify(heroesArr));

}