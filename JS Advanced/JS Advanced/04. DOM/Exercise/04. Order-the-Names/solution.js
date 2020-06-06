function solve() {
    let buttonElement = document.getElementsByTagName("button")[0];
    let inputTextElement = document.getElementsByTagName("input")[0];

    let orderListElement = document.getElementsByTagName("ol")[0];
    let listElements = orderListElement.getElementsByTagName("li");

    buttonElement.addEventListener("click", function () {
        let input = inputTextElement.value;

        let currentName = "";

        if (input){
            currentName += input[0].toUpperCase();

            for (let i = 1; i < input.length; i++) {
                currentName += input[i].toLowerCase();
            }

            let index = currentName.charCodeAt(0) - 65;

            if (listElements[index].textContent.length === 0){
                listElements[index].textContent += currentName;
            }

            else{
                listElements[index].textContent += ", " + currentName;
            }

            inputTextElement.value = "";
        }

    })
}