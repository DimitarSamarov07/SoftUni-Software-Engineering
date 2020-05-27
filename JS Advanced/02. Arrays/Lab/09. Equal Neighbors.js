getEqualNeighboursCount(
    [['2', '2', '5', '7', '4'],
        ['4', '0', '5', '3', '4'],
        ['2', '5', '5', '4', '2']],
);

function getEqualNeighboursCount(inputMatrix) {
    let counter = 0;

    for (let row = 0; row < inputMatrix.length; row++) {
        for (let col = 0; col < inputMatrix[row].length - 1; col++) {
            if (inputMatrix[row][col] === inputMatrix[row][col + 1]) {
                counter++;
            }
        }
    }

    for (let row = 0; row < inputMatrix.length - 1; row++) {
        for (let col = 0; col < inputMatrix[row].length; col++) {
            if (inputMatrix[row][col] === inputMatrix[row + 1][col]) {
                counter++;
            }
        }
    }

    console.log(counter);
}