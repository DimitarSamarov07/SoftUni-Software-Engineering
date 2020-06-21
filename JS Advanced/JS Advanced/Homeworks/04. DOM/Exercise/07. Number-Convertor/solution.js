function solve() {
    let inputElement = document.getElementById("input");
    let selectMenuFrom = document.getElementById("selectMenuFrom")
    let selectMenuTo = document.getElementById("selectMenuTo");
    let convertButton = document.querySelector("button");
    let resultElement = document.getElementById("result");

    let binary = document.createElement("option")
    binary.value = "binary";
    binary.text = "Binary"

    let hex = document.createElement("option")
    hex.value = "hexadecimal";
    hex.text = "Hexadecimal"

    selectMenuTo.appendChild(binary)
    selectMenuTo.appendChild(hex);

    convertButton.addEventListener("click", function () {

        let converter = {
            "decimal binary" : (dec) => (dec >>> 0).toString(2),
            "decimal hexadecimal" : (dec) => dec.toString(16),
        }

        let selectFromValue =  selectMenuFrom.options[selectMenuFrom.selectedIndex].value;
        let selectToValue =  selectMenuTo.options[selectMenuTo.selectedIndex].value;

        let currentConversion = selectFromValue + " " + selectToValue;

        resultElement.value = converter[currentConversion](+inputElement.value).toUpperCase();

    })
}