function growingWord() {
    let word = document.querySelector("#exercise > p");

    if (!word.hasAttribute("style")){
        word.style.color = "blue"
        word.style.fontSize = "2px"
        return;
    }

    let currentColor = word.style.color;
    let currentFontSize = word.style.fontSize;
    currentFontSize = Number(currentFontSize.substr(0, currentFontSize.length - 2));
    let colorChanges = {
        "blue": "green",
        "green": "red",
        "red": "blue"
    };

    word.style.color = colorChanges[currentColor];
    word.style.fontSize = (currentFontSize * 2) + "px";
}