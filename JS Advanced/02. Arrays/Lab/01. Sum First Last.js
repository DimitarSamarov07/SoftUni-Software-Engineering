function sumFirstLast(inputArray) {
    let first = +inputArray[0];
    let last = +inputArray[inputArray.length - 1];

    let sum = first + last;

    return sum;
}