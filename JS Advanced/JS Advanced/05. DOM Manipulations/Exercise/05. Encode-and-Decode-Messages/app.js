function encodeAndDecodeMessages() {
    let inputTextArea = document.querySelector("div > textarea:not(disabled)")
    let outputTextArea = document.querySelector("div > textarea[disabled]")

    let encodeBtn = inputTextArea.parentNode.querySelector("button");
    let decodeBtn = outputTextArea.parentNode.querySelector("button");

    encodeBtn.addEventListener("click", onEncodeBtnClick)
    decodeBtn.addEventListener("click", onDecodeBtnClick)

    function onEncodeBtnClick(){
        let encodedWord = "";

        for (let i = 0; i < inputTextArea.value.length; i++) {
            let newChar = String.fromCharCode(inputTextArea.value[i].charCodeAt(0) + 1);

            encodedWord += newChar;
        }

        outputTextArea.value = encodedWord;
        inputTextArea.value = "";
    }

    function onDecodeBtnClick() {
        let decodedWord = "";

        for (let i = 0; i < outputTextArea.value.length; i++) {
            let newChar = String.fromCharCode(outputTextArea.value[i].charCodeAt(0) - 1);

            decodedWord += newChar;
        }

        outputTextArea.value = decodedWord;
    }
}