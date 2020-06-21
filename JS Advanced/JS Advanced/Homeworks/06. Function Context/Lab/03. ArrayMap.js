function resultMap(arr, fn) {
    return arr.reduce((acc, curr) => {
        return acc.concat(fn(curr));
    }, [])
}
