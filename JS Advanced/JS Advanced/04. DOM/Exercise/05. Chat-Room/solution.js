function solve() {
    let sendButtonElement = document.getElementById("send");
    let inputElement = document.getElementById("chat_input")
    let messagesDiv = document.getElementById("chat_messages");

    sendButtonElement.addEventListener("click", function () {
        let newDiv = document.createElement("div");
        newDiv.className = "message my-message";
        newDiv.textContent = inputElement.value;

        messagesDiv.appendChild(newDiv);

        inputElement.value = "";
    })
}


