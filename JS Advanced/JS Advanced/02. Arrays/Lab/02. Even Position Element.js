function getEvenElements(inputArray) {
    let resultArr =  inputArray.filter((value, index) => index % 2 === 0);

    console.log(resultArr.join(" "));
}