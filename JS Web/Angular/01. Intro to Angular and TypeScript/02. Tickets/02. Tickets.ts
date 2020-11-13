class Ticket {
    public destination: string;
    public price: number;
    public status: string

    constructor(destination: string, price: number, status: string) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}


function convertStringArrToObjArray(arr, orderBy) {
    let objArray = arr.reduce((acc, curr) => {
        const [destination, price, status] = curr.split("|");
        acc.push(new Ticket(destination, Number(price), status))
        return acc;
    }, []);

    switch (orderBy) {
        case "destination":
            objArray = objArray.sort((a, b) => a.destination.localeCompare(b.destination))
            break;
        case "price":
            objArray = objArray.sort((a, b) => a.price - b.price);
            break;
        case "status":
            objArray = objArray.sort((a, b) => a.status.localeCompare(b.status))
            break;
    }

    return objArray;
}

console.log(convertStringArrToObjArray([
        'Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'
    ],
    'destination'))