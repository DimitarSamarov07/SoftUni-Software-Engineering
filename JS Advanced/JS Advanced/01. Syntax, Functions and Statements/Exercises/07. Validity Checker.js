function isDistanceValid(inputArray) {
    let x1 = +inputArray[0];
    let y1 = +inputArray[1];
    let x2 = +inputArray[2];
    let y2 = +inputArray[3];


    let first = Math.pow(y1 - x1, 2)
    let second = Math.pow(0 - 0, 2);
    let third = Math.sqrt(first + second);
    // x1, y1 compared to 0, 0
    let distance1 = Math.sqrt(Math.pow(0 - x1, 2) + Math.pow(0 - x2, 2))

    // x2, y2 compared to 0, 0
    let distance2 = Math.sqrt(Math.pow(0 - x2, 2) + Math.pow(0 - y2,2))

    // x1, y1 compared to x2, y2
    let distance3 = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2))

    if (Number.isInteger(distance1)){
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`)
    }

    else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`)
    }

    if (Number.isInteger(distance2)){
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`)
    }

    else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`)
    }

    if (Number.isInteger(distance3)){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
    }

    else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`)
    }
}