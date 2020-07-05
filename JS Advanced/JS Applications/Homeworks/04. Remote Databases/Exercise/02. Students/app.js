async function fetchData() {
    const tbody = document.querySelector("tbody");

    const url = "https://students-b9eeb.firebaseio.com/Students.json";
    const data = await fetch(url).then(data => data.json());

    data.forEach(async (student, index) => {
        if (index > 0) //firebase issue when not using auto generated id
        {
            await renderStudent(index, student)
        }
    })

    async function renderStudent(index, {facultyNumber, firstName, grade, lastName}) {
        const tr = document.createElement("tr");

        tr.innerHTML = `<th>${index}</th>
                <th>${firstName}</th>
                <th>${lastName}</th>
                <th>${facultyNumber}</th>
                <th>${grade.toFixed(2)}</th>`;

        tbody.appendChild(tr);
    }

}

fetchData();