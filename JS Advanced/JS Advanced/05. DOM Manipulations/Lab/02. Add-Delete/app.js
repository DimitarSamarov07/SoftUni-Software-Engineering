function addItem() {
    let itemsList = document.getElementById("items");
    let textInput = document.getElementById("newText");

    let textInputValue = textInput.value;

    if (!textInputValue) {
        return;
    }

    const li = document.createElement("li");
    const a = document.createElement("a");
    a.innerText = '[Delete]'
    a.href = "#";

    const textNode = document.createTextNode(textInputValue)

    li.appendChild(textNode)
    li.appendChild(a)

    a.addEventListener("click", function (e) {
        e.preventDefault();
        e.target.parentElement.remove()
    })

    itemsList.appendChild(li);
    textInput.value = "";
}