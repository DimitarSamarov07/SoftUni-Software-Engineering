function personalBMI(name, age, weight, height) {
    let bmi = weight / Math.pow(height / 100, 2);
    let status = getStatus(bmi);

    let objToReturn = {
        name: name,
        personalInfo: {
            age: age,
            weight: Math.round(weight),
            height: Math.round(height)
        },
        BMI: Math.round(bmi),
        status: status
    }

    status === "obese" ? objToReturn["recommendation"] = "admission required" : "";

    return objToReturn;

    function getStatus(bmi) {
        if (bmi < 18.5) {
            return "underweight";
        } else if (bmi < 25) {
            return "normal";
        } else if (bmi < 30) {
            return "overweight";
        } else if (bmi >= 30) {
            return "obese";
        }
    }
}