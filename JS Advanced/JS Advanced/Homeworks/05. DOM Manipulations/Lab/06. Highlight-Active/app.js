function focus() {
    let inputElements = document.querySelectorAll('input');

    for (let i = 0, len = inputElements.length; i < len; i++) {
        inputElements[i].addEventListener("focus", onFocus);
        inputElements[i].addEventListener("blur", onBlur);
    }

    function onFocus(e) {
        e.target.parentElement.className = "focused"
    }

    function onBlur(e) {
        e.target.parentElement.className = "";
    }
}