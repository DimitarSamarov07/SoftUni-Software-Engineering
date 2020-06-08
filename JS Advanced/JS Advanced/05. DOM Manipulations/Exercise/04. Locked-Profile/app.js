function lockedProfile() {
    const btns = [...document.getElementsByTagName("button")];

    btns.forEach(btn => btn.addEventListener("click", showHide))

    function showHide(e) {
        const btn = e.target;
        const profile = btn.parentNode;
        const moreInfoDiv = profile.getElementsByTagName('div')[0];
        const lockStatus = profile.querySelector("input[type=radio]:checked").value;

        if (lockStatus === "unlock") {
            if (btn.textContent === "Show more") {
                moreInfoDiv.style.display = "inline-block";
                btn.textContent = "Hide it";
            } else if (btn.textContent === "Hide it") {
                moreInfoDiv.style.display = "none";
                btn.textContent = "Show More";
            }
        }
    }

}