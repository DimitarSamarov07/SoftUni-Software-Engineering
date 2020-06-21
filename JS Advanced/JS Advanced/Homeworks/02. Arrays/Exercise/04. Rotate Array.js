function rotateArray(inputArray) {
    let rotations = Number(inputArray.pop()) % inputArray.length

    for (let i = 0; i < rotations; i++) {
        inputArray.unshift(inputArray.pop());
    }

    console.log(inputArray.join(" "));
}