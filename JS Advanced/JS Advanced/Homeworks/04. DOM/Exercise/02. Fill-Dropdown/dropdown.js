function addItem() {
    let textElement = document.getElementById("newItemText")
    let valueElement = document.getElementById("newItemValue")
    let selectElement = document.getElementById("menu")

    let newOptionElement = document.createElement("option")

    newOptionElement.text = textElement.value;
    newOptionElement.value = valueElement.value;

    selectElement.appendChild(newOptionElement);

    textElement.value = '';
    valueElement.value = '';
}