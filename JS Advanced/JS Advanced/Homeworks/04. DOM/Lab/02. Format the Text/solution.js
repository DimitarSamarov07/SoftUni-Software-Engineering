function solve() {
    let input = document.getElementById("input")
    let outputText = document.getElementById("output")

    const inputContent = input.innerText;

    let sentenceArray = Array.from(inputContent.split("."));

    let currentParagraph = document.createElement("p")

    for (let i = 0; i < sentenceArray.length; i++) {

        currentParagraph.innerText += sentenceArray[i] + ".";
        if (i % 3){
            outputText.appendChild(currentParagraph);
            currentParagraph = document.createElement("p");
        }
    }

    if (sentenceArray.length<3){outputText.appendChild(currentParagraph)}
}