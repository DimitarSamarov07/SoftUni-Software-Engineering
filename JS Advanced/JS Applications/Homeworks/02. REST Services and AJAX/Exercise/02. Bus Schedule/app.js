function solve() {
    const infoSpan = document.querySelector("#info > span");
    const arriveBtn = document.getElementById("arrive");
    const departBtn = document.getElementById("depart");

    let currId = "depot";
    let baseUrl = `https://judgetests.firebaseio.com/schedule/${currId}.json`

    async function depart() {
        departBtn.setAttribute("disabled", true)
        const data = await fetchData();

        infoSpan.textContent = `Next stop: ${data.name}`
        arriveBtn.removeAttribute("disabled");
    }

    async function arrive() {
        const data = await fetchData();

        infoSpan.textContent = `Arriving at ${data.name}`;

        currId = data.next;
        changeUrl();
        arriveBtn.setAttribute("disabled", true);
        departBtn.removeAttribute("disabled");
    }

    async function fetchData() {
        const response = await fetch(baseUrl);
        return await response.json();
    }

    function changeUrl() {
        baseUrl = `https://judgetests.firebaseio.com/schedule/${currId}.json`;
    }


    return {
        depart,
        arrive
    };
}

let result = solve();