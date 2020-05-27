function getDoubledAndReversedOddPositions(inputArray) {
    let newArray = inputArray
        .filter((value, index) => index % 2 !== 0)
        .map((value, index) => {
            return value*2;
        })
        .reverse();

    console.log(newArray.join(" "));
}