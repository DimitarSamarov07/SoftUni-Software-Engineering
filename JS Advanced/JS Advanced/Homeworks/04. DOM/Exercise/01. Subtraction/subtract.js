function subtract() {
    let firstNumberElement = document.getElementById("firstNumber");
    let secondNumberElement = document.getElementById("secondNumber");

    let resultElement = document.getElementById("result");

    let subtractionResult = +firstNumberElement.value - +secondNumberElement.value;

    resultElement.innerText = subtractionResult + ""; //convert to string to follow the convention
}