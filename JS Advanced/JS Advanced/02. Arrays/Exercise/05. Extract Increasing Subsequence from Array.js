function extractIncreasingSubsequence(inputArray) {
    let newArray = inputArray.reduce((acc, curr) => {
        let previousNumber = acc[1];
        if (curr >= previousNumber) {
            acc[0].push(curr);
            acc[1] = curr; //store the current number to be compared in the next iteration
        }
        return acc;
    }, [[], 0])[0] //take the first element of the accumulator aka the array we need
    console.log(newArray.join("\n"));
}