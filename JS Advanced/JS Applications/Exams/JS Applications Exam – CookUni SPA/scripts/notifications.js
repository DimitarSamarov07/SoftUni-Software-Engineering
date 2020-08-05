const [infoBox, loadingBox, errorBox] = document.querySelectorAll(".alert");
const toggleSwitch = {
    true: "block",
    false: "none"
}

const timeoutSwitch = {
    true: (el) => {
        setTimeout(function () {
            el.style.display = "none";
        }, 5000)
    }
}

export function toggleLoading(show) {
    loadingBox.style.display = toggleSwitch[show];
}

export function toggleError(show, message) {
    errorBox.style.display = toggleSwitch[show];
    errorBox.textContent = message;
}

export function toggleInfo(show, message) {
    infoBox.style.display = toggleSwitch[show];
    infoBox.textContent = message;
    if (show) {
        timeoutSwitch[show](infoBox);
    }
}

export function readyNotifications() {
    addNotificationListener(errorBox);
    addNotificationListener(infoBox);
}

function addNotificationListener(el) {
    el.addEventListener("click", function () {
        el.style.display = "none";
    });
}