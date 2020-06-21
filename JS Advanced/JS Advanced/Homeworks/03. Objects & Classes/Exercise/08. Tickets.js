function sortTickets(inputArray, criteria) {

    let tickets = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = +price;
            this.status = status;
        }

    }

    inputArray.forEach(stringData => {
        let [destination, price, status] = stringData.split("|")
        tickets.push(new Ticket(destination, price, status))
    })

    criteria === "destination" ? tickets.sort((a, b) => a.destination.localeCompare(b.destination)) : "";
    criteria === "price" ? tickets.sort((a, b) => a.price - b.price) : "";
    criteria === "status" ? tickets.sort((a, b) => a.status.localeCompare(b.status)) : "";

    return tickets;
}