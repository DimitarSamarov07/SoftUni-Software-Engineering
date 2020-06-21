function toggle() {
    let buttonSpanElement = document.getElementsByClassName("button")[0]
    let divElement = document.getElementById("extra");

    let spanChanges = {
        "More": "Less",
        "Less": "More"
    }

    let divDisplayStyleChanges = {
        "none": "block",
        "" : "block",
        "block": "none"
    }

    let spanTextContent = buttonSpanElement.textContent;
    buttonSpanElement.textContent = spanChanges[spanTextContent];

    let divDisplayStyle = divElement.style.display;
    divElement.style.display = divDisplayStyleChanges[divDisplayStyle];

}