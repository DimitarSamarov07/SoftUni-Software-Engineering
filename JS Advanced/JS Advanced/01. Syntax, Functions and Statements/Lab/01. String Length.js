function solve(arr1, arr2, arr3) {
    let totalLength;
    let averageLength;

    let arr1Length = arr1.length;
    let arr2Length = arr2.length;
    let arr3Length = arr3.length;

    totalLength = arr1Length + arr2Length + arr3Length;
    averageLength = Math.floor(totalLength / 3);
    console.log(totalLength);
    console.log(averageLength);
}