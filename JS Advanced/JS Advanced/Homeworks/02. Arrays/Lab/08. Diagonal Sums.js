function sumOfDiagonals(inputMatrix) {
    let resultArray = inputMatrix.reduce((acc, curr, index) =>{
        acc[0] += curr[index];
        acc[1] += curr[curr.length - 1 - index];
        return acc;
    }, [0, 0])

    console.log(resultArray.join(" "))
}