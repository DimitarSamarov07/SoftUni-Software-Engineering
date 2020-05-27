function addAndRemoveElements(inputArray) {
    let number = 1;
    let array = [];

    inputArray.forEach(x => {
        x === "add" ? array.push(number) : array.pop()
        number++;
    })

    if (array.length !== 0) {
        console.log(array.join("\n"))
    } else {
        console.log("Empty")
    }
}