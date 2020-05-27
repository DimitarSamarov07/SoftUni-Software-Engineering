// [
// [4, 5, 6],
// [6, 5, 4],        an example of a ,,magical" array - the sums of the cells of every row and every column are equal.
// [5, 5, 5]
// ]

function isArrayMagical(inputArray) {
    let sumsSet = new Set;

    for (let row = 0; row < inputArray.length; row++) {
        sumsSet.add(inputArray[row].reduce((x, y) => x + y))
        let colSum = 0;
        for (let col = 0; col < inputArray.length; col++) {
            colSum += inputArray[col][row];
        }
        sumsSet.add(colSum);
        colSum = 0;
    }

    console.log(sumsSet.size === 1);
}