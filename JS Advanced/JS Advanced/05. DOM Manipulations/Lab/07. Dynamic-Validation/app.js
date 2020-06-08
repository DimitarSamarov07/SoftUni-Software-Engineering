function validate() {
    let inputEmailElement = document.getElementById("email");

    inputEmailElement.addEventListener("change", function () {
        const regExp = /^[a-z-.]+@[a-z.]+\.[a-z]/g
        let inputValue = inputEmailElement.value;

        !regExp.test(inputValue) ? inputEmailElement.classList.add('error') : inputEmailElement.classList.remove('error')
    })
}