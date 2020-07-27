const [infoBox, errorBox] = document.querySelectorAll(".notification");
const toggleSwitch = {
    true: "block",
    false: "none"
}

export function toggleError(show, message) {
    errorBox.style.display = toggleSwitch[show];
    errorBox.textContent = message;
}

export function toggleInfo(show, message) {
    infoBox.style.display = toggleSwitch[show];
    infoBox.textContent = message;
}