function getArgumentInfo() {
    let map = new Map();

    for (const arg of arguments) {
        let type = typeof arg;
        if (!map.has(type)) {
            map.set(type, 0);
        }

        map.set(type, map.get(type) + 1);

        console.log(`${type}: ${arg}`)
    }

    [...map.entries()].sort((a, b) => b[1] - a[1])
        .forEach((item) => console.log(`${item[0]} = ${item[1]}`));
}