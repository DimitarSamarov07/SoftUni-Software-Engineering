function getTheTwoSmallestNumbers(inputArray) {
    let newArray = inputArray.sort((function (a, b) {
        return a - b
    })).slice(0, 2);

    console.log(newArray.join(" "));
}