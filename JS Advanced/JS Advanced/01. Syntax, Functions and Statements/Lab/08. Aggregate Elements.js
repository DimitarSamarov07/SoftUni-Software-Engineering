function solve(inputArray) {
    let result = 0;
    for (let item of inputArray) {
        result += item;
    }
    console.log(result);

    result = 0;

    for (let item of inputArray) {
        result += 1 / item;
    }

    console.log(result);

    result = "";

    for (let num of inputArray) {
        result = result.concat(num);
    }
    console.log(result);
}