const [infoBox, loadingBox, errorBox] = document.querySelectorAll(".alert");
const toggleSwitch = {
    true: "block",
    false: "none"
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
}