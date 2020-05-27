function negativeAndPositiveNumbers(inputArray) {
    let resultArray = [];
    for (let num of inputArray) {
        num >= 0 ? resultArray.push(num) : resultArray.unshift(num);
    }

    console.log(resultArray.join("\n"));
}