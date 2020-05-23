function draw(num) {
    if (num === undefined) {
        num = 5
    }

    for (let i = 0; i < num; i++) {
        console.log("* ".repeat(num))
    }
}