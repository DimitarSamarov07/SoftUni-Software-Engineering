function stopwatch() {
    let seconds = 0;
    let minutes = 0;
    let intervalID;

    const timeDiv = document.getElementById("time");
    const startBtn = document.getElementById("startBtn");
    const stopBtn = document.getElementById("stopBtn");

    function startBtnHandler() {
        startBtn.setAttribute("disabled", true)
        stopBtn.removeAttribute("disabled")

        reset();

        intervalID = setInterval(function () {
            seconds++;
            if (seconds === 60) {
                seconds = 0;
                minutes++;
            }
            timeDiv.innerText = getTimeString();
        }, 1000)
    }

    function stopBtnHandler() {
        stopBtn.setAttribute("disabled", true)
        startBtn.removeAttribute("disabled")

        clearInterval(intervalID)
    }

    function reset() {
        seconds = 0;
        minutes = 0;
        timeDiv.innerText = "00:00"
    }

    function getTimeString() {
        let minutesText = minutes.toString();
        let secondsText = seconds.toString();

        if (minutes < 10) {
            minutesText = "0" + minutesText;
        }
        if (seconds < 10) {
            secondsText = "0" + secondsText;
        }

        return `${minutesText}:${secondsText}`
    }

    startBtn.addEventListener("click", startBtnHandler)
    stopBtn.addEventListener("click", stopBtnHandler)
}