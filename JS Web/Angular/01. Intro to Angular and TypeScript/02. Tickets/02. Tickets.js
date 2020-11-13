var Ticket = /** @class */ (function () {
    function Ticket(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }

    return Ticket;
}());

function convertStringArrToObjArray(arr, orderBy) {
    var objArray = arr.reduce(function (acc, curr) {
        var _a = curr.split("|"), destination = _a[0], price = _a[1], status = _a[2];
        acc.push(new Ticket(destination, Number(price), status));
        return acc;
    }, []);
    switch (orderBy) {
        case "destination":
            objArray = objArray.sort(function (a, b) {
                return a.destination.localeCompare(b.destination);
            });
            break;
        case "price":
            objArray = objArray.sort(function (a, b) {
                return a.price - b.price;
            });
            break;
        case "status":
            objArray = objArray.sort(function (a, b) {
                return a.status.localeCompare(b.status);
            });
            break;
    }
    return objArray;
}

console.log(convertStringArrToObjArray([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], 'destination'));
