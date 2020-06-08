function attachEventsListeners() {
    let daysInput = document.getElementById("days")
    let daysBtn = document.getElementById("daysBtn")

    let hoursInput = document.getElementById("hours")
    let hoursBtn = document.getElementById("hoursBtn")

    let minutesInput = document.getElementById("minutes")
    let minutesBtn = document.getElementById("minutesBtn")

    let secondsInput = document.getElementById("seconds")
    let secondsBtn = document.getElementById("secondsBtn")

    daysBtn.addEventListener("click",onDaysBtnClick)
    hoursBtn.addEventListener("click",onHoursBtnClick)
    minutesBtn.addEventListener("click",onMinutesBtnClick);
    secondsBtn.addEventListener("click", onSecondsBtnClick)

    function onDaysBtnClick() {
        let daysConverter = {
            "days": (days) => days,
            "hours": (days) => days * 24, // 1 day = 24 hours
            "minutes": (days) => days * 1440, // 1 day = 1440 minutes
            "seconds": (days) => days * 86400 // 1 day = 86400 seconds
        }

        let inputValue = +daysInput.value;

        convertUsingConvertObj(daysConverter, inputValue);
    }

    function onHoursBtnClick() {
        let hoursConverter = {
            "days": (hours) => hours / 24, // 24 hours = 1 day
            "hours": (hours) => hours,
            "minutes": (hours) => hours * 60, // 1 hour = 60 minutes
            "seconds": (hours) => hours * 3600 // 1 hour = 3600 seconds
        }

        let inputValue = +hoursInput.value;

        convertUsingConvertObj(hoursConverter, inputValue);
    }

    function onMinutesBtnClick() {
        let minutesConverter = {
            "days": (minutes) => minutes / 1440, // 1440 minutes = 1 day
            "hours": (minutes) => minutes / 60, // 60 minutes = 1 hour
            "minutes": (minutes) => minutes,
            "seconds": (minutes) => minutes * 60 // 1 minute  = 60 seconds
        }

        let inputValue = +minutesInput.value;

        convertUsingConvertObj(minutesConverter, inputValue);
    }

    function onSecondsBtnClick() {
        let secondsConverter = {
            "days": (seconds) => seconds / 86400, // 86400 seconds = 1 day
            "hours": (seconds) => seconds / 3600, // 3600 seconds = 1 hour
            "minutes": (seconds) => seconds / 60, // 60 seconds = 1 minute
            "seconds": (seconds) => seconds
        }

        let inputValue = +secondsInput.value;

        convertUsingConvertObj(secondsConverter, inputValue);
    }

    function convertUsingConvertObj(converter, input) {
        daysInput.value = converter["days"](input);
        hoursInput.value = converter["hours"](input);
        minutesInput.value = converter["minutes"](input);
        secondsInput.value = converter["seconds"](input);
    }
}