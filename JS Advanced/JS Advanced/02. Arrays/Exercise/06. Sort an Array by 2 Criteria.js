function sortBy2Criteria(inputArray) {
    let sortedArray = inputArray.sort(((a, b) => a.length - b.length || a.localeCompare(b)))

    console.log(sortedArray.join("\n"));
}