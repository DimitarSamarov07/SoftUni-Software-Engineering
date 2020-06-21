function solution() {
    let str = "";

    return {
        append: (s) => str += s,
        removeStart: (n) => str = str.substr(n),
        removeEnd: (n) => str = str.substr(0, str.length - n),
        print: () => console.log(str)
    }
}