function solve() {
    const divElements = Array.from(document.querySelectorAll(".middled  div"));

    for (let i = 0; i < divElements.length; i++) {
        let element = divElements[i];
        element.id = `link${i}`;
        element.children[0].addEventListener('click', function () {
            let spanElement = document.querySelector(`#${element.id} p`);

            let count = Number(spanElement.innerText.match(/\d+/));
            spanElement.innerText = spanElement.innerText.replace(/\d+/, ++count);
        })
    }
}