function solve() {
    let trList = document.querySelectorAll("tbody > tr");
    Array.from(trList).forEach(x => x.addEventListener("click", onTrClick))

    function onTrClick(e) {
        let element = e.target.parentElement;

        if (element.style.backgroundColor === "") {
            clearStyle();
            element.style.backgroundColor = "#413f5e";
            return;
        }

        element.style.backgroundColor = "";

    }

    function clearStyle() {
        Array.from(trList).forEach(x => x.style.backgroundColor = "");
    }
}
