function getSumByTown(inputArray) {
    let townObj = {};
    for (let i = 0; i < inputArray.length; i += 2) {
        let town = inputArray[i];
        let income = +inputArray[i + 1];

        if (Object.keys(townObj).includes(town)) {
            townObj[town] += income;
        } else {
            townObj[town] = income;
        }
    }

    console.log(JSON.stringify(townObj))
}