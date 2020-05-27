function printElementsSum(n, k) {
    let resultArr = [1];

    for(let i=1; i<n; i++) {
        let startIndex = Math.max(0, i-k);
        let currentElement = resultArr.slice(startIndex, startIndex + k).reduce((a, b) => a + b, 0);
        resultArr.push(currentElement);
    }

    console.log(resultArr.join(" "));
}
