function notify(message) {
    let notificationDiv = document.getElementById("notification");

    notificationDiv.style.display = "block"
    notificationDiv.textContent = message;

    let timeoutID = setTimeout(function () {
        notificationDiv.style.display = "none"
        notificationDiv.textContent = "";

        clearTimeout(timeoutID);
    }, 2000)
}