getCars(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'])

function getCars(inputArray) {
    let cars = {};

    for (let curr of inputArray) {
        let [brand, model, unitsProduced] = curr.split(" | ");

        unitsProduced = +unitsProduced

        !cars.hasOwnProperty(brand) ? cars[brand] = {} : '';

        cars[brand].hasOwnProperty(model) ? cars[brand][model] += unitsProduced : cars[brand][model] = unitsProduced;
    }
    
    const precedingString = "#".repeat(3);

    for (let [brand, models] of Object.entries(cars)) {
        console.log(brand)
        for (let [model, unitsProduced] of Object.entries(models)) {

            console.log(precedingString + `${model} -> ${unitsProduced}`)
        }

    }
}