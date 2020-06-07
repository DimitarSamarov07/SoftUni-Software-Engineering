function deleteByEmail() {
    const emailTds = Array.from(document.querySelectorAll("#customers tr td:last-child"))
    const emailInput = document.querySelector('input[name="email"]')
    const resultDiv = document.getElementById("result")
    const emailInputValue = emailInput.value;

    if (!emailInputValue) { return; }

    const tdToDelete = emailTds.find(function (td) {
        return td.innerText === emailInputValue;
    })

    if (!tdToDelete){
        resultDiv.innerText = "Not found."
        return;
    }

    tdToDelete.parentElement.remove();

    emailInput.value = "";
    resultDiv.innerText = "Deleted."
}