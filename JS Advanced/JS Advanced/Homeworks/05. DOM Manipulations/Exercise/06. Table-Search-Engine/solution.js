// Smart, super simple and judge approved solution
function solve() {
    let nameTds = document.querySelectorAll("tbody > tr > td");
    let searchField = document.getElementById("searchField");
    let searchBtn = document.getElementById("searchBtn");

    searchBtn.addEventListener("click", onSearchBtnClick)

    function onSearchBtnClick() {
        clearSelectClass(nameTds);
        let searchString = searchField.value;
        let matches = [];
        for (let i = 0; i < nameTds.length; i++) {
            let tdValue = nameTds[i].textContent;

            if (tdValue.includes(searchString)) {
                matches.push(nameTds[i]);
            }
        }

        if (matches.length > 0) {
            matches.forEach(x => x.parentNode.classList.add("select"))
        }
        searchField.value = "";
    }

    function clearSelectClass(nodeList) {

        for (let i = 0; i < nodeList.length; i++) {
            nodeList[i].parentNode.classList.remove("select")
        }
    }
}


// Dumb, not judge approved solution(83/100 points). For me it still works though :D
function solve2() {
    let nameTds = document.querySelectorAll("tbody > tr > td");
    let searchField = document.getElementById("searchField");
    let searchBtn = document.getElementById("searchBtn");

    searchBtn.addEventListener("click", onSearchBtnClick)

    function onSearchBtnClick() {

        clearSelectClass(nameTds)
        let searchString = searchField.value.toLowerCase();
        let matches = [];

        for (let i = 0; i < nameTds.length; i++) {
            let isItMatch = false;
            let tdValue = nameTds[i].textContent.toLowerCase();

            isItMatch = [...searchString].every(x => {
                return tdValue.indexOf(x) > -1;
            })

            if (isItMatch) {
                matches.push(nameTds[i]);
            }
        }

        if (matches.length > 0) {
            matches.forEach(x => x.parentNode.classList.add("select"))
        }
        searchField.value = "";

        function clearSelectClass(nodeList) {

            for (let i = 0; i < nodeList.length; i++) {
                nodeList[i].parentNode.classList.remove("select")
            }
        }
    }


}
