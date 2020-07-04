function attachEvents() {
    const locationInput = document.getElementById("location");
    const forecastDiv = document.getElementById("forecast");
    const currentDiv = document.getElementById("current");
    const upcomingDiv = document.getElementById("upcoming");

    const initialCurrentDivState = currentDiv.cloneNode(true);
    const initialUpcomingDivState = upcomingDiv.cloneNode(true);

    const submitBtn = document.getElementById("submit");
    submitBtn.addEventListener("click", onSubmitBtnClick)

    async function onSubmitBtnClick() {
        await reset();

        const locationsUrl = "https://judgetests.firebaseio.com/locations.json";

        const locations = await fetch(locationsUrl).then(data => data.json()).catch(() => {
            setForecastToError();
        })

        const neededObj = locations.find(x => x.name === locationInput.value);

        !neededObj ? await setForecastToError() : "";

        await getAndSetTodaysForecast(neededObj.code);
        await getAndSetUpcomingForecast(neededObj.code);

    }

    async function getAndSetTodaysForecast(code) {

        const {forecast: {condition, high, low}, name} = await fetch(`https://judgetests.firebaseio.com/forecast/today/${code}.json`)
            .then(data => data.json())
            .catch(() => {
                setForecastToError()
            });

        const symbol = await getSymbolToUse(condition);

        const newForecastDiv = document.createElement("div")
        newForecastDiv.className = "forecasts";

        const symbolSpan = document.createElement("span");
        symbolSpan.className = "condition symbol";
        symbolSpan.innerHTML = symbol;

        newForecastDiv.appendChild(symbolSpan);

        newForecastDiv.innerHTML +=
            "<span class='condition'>" +
            `<span class='forecast-data'>${name}</span>` +
            `<span class='forecast-data'>${low}°/${high}°/</span>` +
            `<span class='forecast-data'>${condition}</span>` +
            "</span>";

        currentDiv.appendChild(newForecastDiv);
        forecastDiv.style.display = "block"
    }

    async function getAndSetUpcomingForecast(code) {

        const {forecast: forecasts} = await fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`)
            .then(data => data.json())
            .catch(() => {
                setForecastToError()
            });

        for (const {condition, high, low} of forecasts) {
            const symbol = await getSymbolToUse(condition);

            const newForecastDiv = document.createElement("div")
            newForecastDiv.className = "forecast-info";

            const symbolSpan = document.createElement("span");
            symbolSpan.className = "symbol";
            symbolSpan.innerHTML = symbol;

            newForecastDiv.appendChild(symbolSpan);

            newForecastDiv.innerHTML +=
                "<span class='upcoming'>" +
                `<span class='forecast-data'>${low}°/${high}°/</span>` +
                `<span class='forecast-data'>${condition}</span>` +
                "</span>";

            upcomingDiv.appendChild(newForecastDiv);
        }
    }

    async function setForecastToError() {
        forecastDiv.style.display = "block";
        currentDiv.innerHTML += "Error";
        upcomingDiv.innerHTML += "Error";
    }

    async function reset() {
        currentDiv.innerHTML = initialCurrentDivState.innerHTML;
        upcomingDiv.innerHTML = initialUpcomingDivState.innerHTML;
    }

    async function getSymbolToUse(condition) {
        const charObj = {
            Sunny: "&#x2600;",
            "Partly sunny": "&#x26C5;",
            Overcast: "&#x2601",
            Rain: "&#x2614",

        }

        return charObj[condition];
    }
}

attachEvents();