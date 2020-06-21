function solve() {
    const player1Cards = document.querySelectorAll("#player1Div > img")
    const player2Cards = document.querySelectorAll("#player2Div > img")
    const history = document.getElementById("history");
    const span1 = document.querySelector("#result > span:first-of-type")
    const span2 = document.querySelector("#result > span:last-of-type")


    Array.from(player1Cards).forEach(x => x.addEventListener("click", onPlayer1CardClick))
    Array.from(player2Cards).forEach(x => x.addEventListener("click", onPlayer2CardClick))

    let firstTarget;
    let secondTarget;

    function onPlayer1CardClick(e) {
        const card = e.target
        span1.textContent = card.name;

        card.src = "images/whiteCard.jpg";

        firstTarget = card;

        markGreaterCard();
    }

    function onPlayer2CardClick(e) {
        const card = e.target

        span2.textContent = card.name;

        card.src = "images/whiteCard.jpg";

        secondTarget = card;

        markGreaterCard();
    }

    function markGreaterCard() {
        if (firstTarget && secondTarget) {
            let actualValue1 = +firstTarget.name;
            let actualValue2 = +secondTarget.name;

            if (actualValue1 > actualValue2) {
                firstTarget.style.border = "2px solid green"
                secondTarget.style.border = "2px solid red"
            } else {
                firstTarget.style.border = "2px solid red"
                secondTarget.style.border = "2px solid green"
            }

            history.textContent += `[${actualValue1} vs ${actualValue2}] `
            span1.textContent = "";
            span2.textContent = "";
            firstTarget = null;
            secondTarget = null;
        }

    }
}