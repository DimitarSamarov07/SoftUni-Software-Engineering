const [errorBox, infoBox] = document.querySelectorAll(".notification-message");
const [errorSection, infoSection] = document.querySelectorAll(".notifications");
const toggleSwitch = {
    true: "block",
    false: "none"
}

const timeoutSwitch = {
    true: (el) => {
        setTimeout(function () {
            el.style.display = "none";
        }, 1000)
    }
}

export function toggleError(show, message) {
    errorSection.style.display = toggleSwitch[show];
    errorBox.textContent = message;

    if (show) {
        timeoutSwitch[show](errorSection);
    }
}

export function toggleInfo(show, message) {
    infoSection.style.display = toggleSwitch[show];
    infoBox.textContent = message;
    if (show) {
        timeoutSwitch[show](infoSection);
    }
}