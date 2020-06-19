function solution(inputStr) {
    const resultObj = {};

    let inputArr = JSON.parse(inputStr); //eval is also an option, not very safe though

    inputArr.forEach(x => {
        Object.entries(x).forEach(([key, value]) => resultObj[key] = value);
    })

    return resultObj;
}