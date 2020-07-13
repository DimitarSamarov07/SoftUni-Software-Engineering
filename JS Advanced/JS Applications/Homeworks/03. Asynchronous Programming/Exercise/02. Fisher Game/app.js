function attachEvents() {
    const catchesDiv = document.getElementById("catches");

    const addBtn = document.querySelector("button.add");
    const loadBtn = document.querySelector("button.load");

    addBtn.addEventListener("click", onAddBtnClick)
    loadBtn.addEventListener("click", onLoadBtnCLick)

    async function onAddBtnClick(e) {
        const formId = e.target.parentElement.id;
        const url = "https://fisher-game.firebaseio.com/catches.json";

        const [{value: angler}, {value: weight},
            {value: species}, {value: location},
            {value: bait}, {value: captureTime}] = document
            .querySelectorAll(`#${formId} > input`)

        const objToPost = {angler, weight, species, location, bait, captureTime};

        await fetch(url, {
            method: "POST",
            body: JSON.stringify(objToPost)
        })
            .then(() => onLoadBtnCLick()) //reload
            .catch(() => console.warn("Sorry server is dead :/"));
    }

    async function onUpdateBtnClick(e) {
        const catchId = e.target.parentElement.getAttribute("data-id");
        const url = ` https://fisher-game.firebaseio.com/catches/${catchId}.json`;

        const [{value: angler}, {value: weight},
            {value: species}, {value: location},
            {value: bait}, {value: captureTime}] = document
            .querySelectorAll(`[data-id=${catchId}] > input`)

        const objToPost = {angler, weight, species, location, bait, captureTime};

        await fetch(url, {
            method: "PUT",
            body: JSON.stringify(objToPost)
        })
            .then(() => onLoadBtnCLick()) //reload
            .catch(() => console.warn("Sorry server is dead :/"));


    }

    async function onDeleteBtnClick(e) {
        const catchId = e.target.parentElement.getAttribute("data-id");

        const url = `https://fisher-game.firebaseio.com/catches/${catchId}.json`;

        await fetch(url, {
            method: "DELETE",
        })
            .then(() => onLoadBtnCLick()) //reload
            .catch(() => console.warn("Sorry server is dead :/"));
    }

    async function onLoadBtnCLick() {
        const url = "https://fisher-game.firebaseio.com/catches.json";

        const catches = await fetch(url).then(data => data.json())
            .catch(() => console.warn("Sorry server is dead :/"));

        catchesDiv.innerHTML = "";

        Object.entries(catches)
            .forEach(x => {
                renderCatch(x);
            })
    }

    async function renderCatch([id, {angler, bait, captureTime, location, species, weight}]) {
        const divElement = document.createElement("div");
        divElement.className = "catch";
        divElement.setAttribute("data-id", id);
        divElement.innerHTML =
            `<label>Angler</label>
                <input type="text" class="angler" value="${angler}"/>
                <hr>
                <label>Weight</label>
                <input type="number" class="weight" value="${weight}"/>
                <hr>
                <label>Species</label>
                <input type="text" class="species" value="${species}"/>
                <hr>
                <label>Location</label>
                <input type="text" class="location" value="${location}"/>
                <hr>
                <label>Bait</label>
                <input type="text" class="bait" value="${bait}"/>
                <hr>
                <label>Capture Time</label>
                <input type="number" class="captureTime" value="${captureTime}"/>
                <hr>`;

        const updateBtn = document.createElement("button");
        updateBtn.textContent = "Update";
        updateBtn.addEventListener("click", onUpdateBtnClick)

        const deleteBtn = document.createElement("button");
        deleteBtn.textContent = "Delete"
        deleteBtn.addEventListener("click", onDeleteBtnClick);

        divElement.append(updateBtn, deleteBtn);

        catchesDiv.appendChild(divElement);

    }

}

attachEvents();

