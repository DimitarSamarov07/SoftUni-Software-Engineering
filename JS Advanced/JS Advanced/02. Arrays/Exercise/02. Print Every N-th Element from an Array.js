function getEveryNthElementOfAnArray(inputArray) {
    let n = +inputArray.pop();

    for (let i = 0; i < inputArray.length; i += n) {
        console.log(inputArray[i]);
    }
}