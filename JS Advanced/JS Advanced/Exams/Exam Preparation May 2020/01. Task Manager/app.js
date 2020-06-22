function solve() {

    const openDiv = document.querySelector("section > div > .orange").parentElement.nextElementSibling;
    const inProgressDiv = document.getElementById("in-progress");
    const completeDiv = document.querySelector("section > div > .green").parentElement.nextElementSibling;

    const taskInput = document.getElementById("task");
    const descriptionTextArea = document.getElementById("description");
    const dateInput = document.getElementById("date");

    const addBtn = document.getElementById("add");

    addBtn.addEventListener("click", onAddBtnClick)

    function onAddBtnClick(e) {
        if (validateFields()) {

            const article = document.createElement("article");

            const divFlex = document.createElement("div")
            divFlex.setAttribute("class", "flex");

            const h3 = document.createElement("h3")
            h3.textContent = taskInput.value;

            const pDescription = document.createElement("p");
            pDescription.textContent = "Description: " + descriptionTextArea.value;

            const pDate = document.createElement("p");
            pDate.textContent = "Due Date: " + dateInput.value;

            const startBtn = document.createElement("button")
            startBtn.setAttribute("class", "green");
            startBtn.textContent = "Start";
            startBtn.addEventListener("click", onStartBtnClick)

            const deleteBtn = document.createElement("button")
            deleteBtn.setAttribute("class", "red");
            deleteBtn.textContent = "Delete";
            deleteBtn.addEventListener("click", onDeleteBtnClick)


            divFlex.appendChild(startBtn)
            divFlex.appendChild(deleteBtn);

            article.appendChild(h3)     // ParentNode.append() can be used to append multiple children
                                        // on versions of Node after 2016
            article.appendChild(pDescription)
            article.appendChild(pDate)
            article.appendChild(divFlex);

            openDiv.appendChild(article);

        }
        e.preventDefault();
    }

    function onDeleteBtnClick(e) {
        e.target.parentElement.parentElement.remove();
    }

    function onStartBtnClick(e) {
        let copy = e.target.parentElement.parentElement;
        e.target.parentElement.parentElement.remove();

        copy.lastChild.innerHTML = "";

        const deleteBtn = document.createElement("button")
        deleteBtn.setAttribute("class", "red");
        deleteBtn.textContent = "Delete";
        deleteBtn.addEventListener("click", onDeleteBtnClick)

        const finishBtn = document.createElement("button");
        finishBtn.setAttribute("class", "orange");
        finishBtn.textContent = "Finish";
        finishBtn.addEventListener("click", onFinishBtnClick);

        copy.lastChild.appendChild(deleteBtn);
        copy.lastChild.appendChild(finishBtn);

        inProgressDiv.appendChild(copy);
        v
    }

    function onFinishBtnClick(e) {
        let copy = e.target.parentElement.parentElement;
        e.target.parentElement.parentElement.remove();

        copy.lastChild.remove();

        completeDiv.appendChild(copy);

    }

    function validateFields() {
        return taskInput && descriptionTextArea && dateInput;
    }
}