async function fillContacts() {
    const template = await fetch("./template.hbs")
        .then(data => data.text());

    const contactsDiv = document.getElementById("contacts");

    const contacts = [
        {
            id: 1,
            name: "John",
            phoneNumber: "0847759632",
            email: "john@john.com"
        },
        {
            id: 2,
            name: "Merrie",
            phoneNumber: "0845996111",
            email: "merrie@merrie.com"
        },
        {
            id: 3,
            name: "Adam",
            phoneNumber: "0866592475",
            email: "adam@stamat.com"
        },
        {
            id: 4,
            name: "Peter",
            phoneNumber: "0866592475",
            email: "peter@peter.com"
        },
        {
            id: 5,
            name: "Max",
            phoneNumber: "0866592475",
            email: "max@max.com"
        },
        {
            id: 6,
            name: "David",
            phoneNumber: "0866592475",
            email: "david@david.com"
        }
    ];

    const contactsTemplate = Handlebars.compile(template);

    const context = {contacts};
    contactsDiv.innerHTML += (contactsTemplate(context));

    const btns = document.querySelectorAll(".detailsBtn");
    btns.forEach((btn) => {
        btn.addEventListener("click", toggleDetails)
    })

    function toggleDetails(e) {
        const btn = e.target;
        let div = e.target.nextElementSibling

        const displaySwitch = {
            "none": "block",
            "": "block",
            "block": "none",
        }

        const btnTextSwitch = {
            "Details": "Hide",
            "Hide": "Details"
        }

        div.style.display = displaySwitch[div.style.display];
        btn.textContent = btnTextSwitch[btn.textContent];
    }
}


fillContacts();