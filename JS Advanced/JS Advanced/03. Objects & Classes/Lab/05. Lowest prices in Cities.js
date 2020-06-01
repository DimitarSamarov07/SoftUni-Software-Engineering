function getLowestPrice(inputArray) {
    let map = new Map();

    for (let i = 0; i < inputArray.length; i++) {
        let [town, product, price] = inputArray[i].split(" | ");

        if (!map.has(product)){
            map.set(product, new Map());
        }

        map.get(product).set(town, +price)
    }

    for (let [product, innerMap] of map) {
        let lowestPrice = Number.POSITIVE_INFINITY;
        let townWithLowestPrice = "";

        for (let [town, price] of innerMap) {
            if (price < lowestPrice){
                lowestPrice = price;
                townWithLowestPrice = town;
            }
        }

        console.log(`${product} -> ${lowestPrice} (${townWithLowestPrice})`)
    }
}