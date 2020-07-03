function getInfo() {
    const stopIdInput = document.getElementById("stopId");
    const stopNameDiv = document.getElementById("stopName");
    const busesUl = document.getElementById("buses");

    const validIDs = ["1287", "1308", "1327", "2334"]

    const stopId = stopIdInput.value;

    stopNameDiv.textContent = "";
    busesUl.innerHTML = "";

    if (validIDs.includes(stopId)) {
        const baseUrl = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;

        let resultObj;

        fetch(baseUrl)
            .then(data => data.json())
            .then(item => {
                resultObj = item
            })
            .then(() => {
                stopNameDiv.textContent = resultObj.name;

                for (const [busId, time] of Object.entries(resultObj.buses)) {
                    const li = document.createElement("li");

                    li.textContent = `Bus ${busId} arrives in ${time} minutes`;

                    busesUl.appendChild(li);
                }
            })


    } else {
        stopNameDiv.textContent = "Error";
    }
}