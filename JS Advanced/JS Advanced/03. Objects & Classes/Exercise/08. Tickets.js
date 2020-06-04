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

    criteria === "destination" ? tickets = tickets.sort((a,b) => a.destination.localeCompare(b.destination)) : "";
    criteria === "price" ? tickets = tickets.sort((a,b) => a.price - b.price) : "";
    criteria === "status" ? tickets = tickets.sort((a,b) => a.destination.localeCompare(b.destination)) : "";

    return tickets;
}