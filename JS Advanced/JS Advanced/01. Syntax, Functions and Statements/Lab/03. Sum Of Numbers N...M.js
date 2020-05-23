function solve(n, m) {
    let result = 0;
    let num1 = +n;
    let num2 = +m;

    for (let i = num1; i <= num2; i++) {
        result += i;
    }

    console.log(result)
}
