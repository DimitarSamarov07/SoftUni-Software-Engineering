function attachGradientEvents() {
    let gradient = document.getElementById("gradient");
    let resultDiv = document.getElementById("result");
    gradient.addEventListener("mousemove",gradientMove)
    gradient.addEventListener("mouseout", gradientOut)

    function gradientMove(e) {
        let power = e.offsetX / (e.target.clientWidth - 1);
        power = Math.trunc(power * 100);
        resultDiv.textContent = power + "%"
    }

    function gradientOut() {
        resultDiv.textContent = "";
    }
}