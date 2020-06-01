getPopulationsInTowns(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
)

function getPopulationsInTowns(inputArray) {
    let townObj = {};
    for (let i = 0; i < inputArray.length; i++) {
        let [town, population] = inputArray[i].split(" <-> ");

        population = +population;

        if (Object.keys(townObj).includes(town)) {
            townObj[town] += population;
        } else {
            townObj[town] = population;
        }
    }

    Object.entries(townObj).forEach(
        ([key, value]) => console.log(`${key} : ${value}`));
}