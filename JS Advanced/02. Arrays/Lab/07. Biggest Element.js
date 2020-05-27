function getBiggestElement(inputArray) {
    let max = inputArray.map((currRow) => {
        return Math.max.apply(null, currRow); //will return the max value for each array
    }).reduce(function (a, b) {
        return Math.max(a, b);  // and then take the biggest value of all arrays
    });

    console.log(max);
}