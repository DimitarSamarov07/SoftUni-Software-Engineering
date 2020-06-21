isWithinSpeedLimit([200, 'motorway'])
function isWithinSpeedLimit(inputArray) {
    let inputSpeed = +inputArray[0];
    let inputArea = inputArray[1];
    let speedOverLimit = 0;
    let output = "";

    switch (inputArea) {
        case "motorway":
            speedOverLimit = inputSpeed - 130;
            break;
        case "interstate":
            speedOverLimit = inputSpeed - 90;
            break;
        case "city":
            speedOverLimit = inputSpeed - 50;
            break;
        case "residential":
            speedOverLimit = inputSpeed - 20;
            break;
        default:
            break;
    }

    if (speedOverLimit > 0){
        if (speedOverLimit <= 20 ){
            console.log("speeding");
        }

        else if (speedOverLimit <= 40){
            console.log("excessive speeding");
        }

        else{
            console.log("reckless driving")
        }
    }
}