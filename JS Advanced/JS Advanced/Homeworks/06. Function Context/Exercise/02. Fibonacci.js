function getFibonator() {
    let previous = 1;
    let curr = 0;

    return fibonator;

    function fibonator() {
        let newNumber = previous + curr;
        curr = previous;
        previous = newNumber;

        return curr;
    }
}