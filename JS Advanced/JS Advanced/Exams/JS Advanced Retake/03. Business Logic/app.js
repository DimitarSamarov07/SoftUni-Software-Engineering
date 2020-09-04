class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName;
        this.ticketPrice = Number(ticketPrice);
        this.screenings = [];
        this.totalProfit = 0;
        this.soldTickets = 0;
    }

    newScreening(date, hall, description) {
        if (this.screenings.find(x => x.date === date && x.hall === hall)) {
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`)
        }

        this.screenings.push({date, hall, description});
        return `New screening of ${this.movieName} is added.`;
    }

    endScreening(date, hall, soldTickets) {
        const screening = this.screenings.find(x => x.date === date && x.hall === hall)
        if (!screening) {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`)
        }

        const profit = this.ticketPrice * soldTickets;
        this.totalProfit += profit;
        this.soldTickets += soldTickets;

        this.screenings.splice(this.screenings.indexOf(screening), 1);


        return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${profit}`
    }

    toString() {
        let result = `${this.movieName} full information:\nTotal profit: ${this.totalProfit.toFixed(0)}$\nSold Tickets: ${this.soldTickets}\n`;

        if (this.screenings.length > 0) {
            result += "Remaining film screenings:\n";
            result += this.screenings
                .sort((a, b) => a.hall.localeCompare(b.hall))
                .reduce((acc, {hall, date, description}) => {
                    return acc += `${hall} - ${date} - ${description}\n`;
                }, "");
        } else {
            result += "No more screenings!"
        }

        return result.trimEnd();
    }
}

let m = new Movie('Wonder Woman 1984', '10.00');
console.log(m.newScreening('October 2, 2020', 'IMAX 3D', `3D`));
console.log(m.newScreening('October 3, 2020', 'Main', `regular`));
console.log(m.newScreening('October 4, 2020', 'IMAX 3D', `3D`));
console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
console.log(m.endScreening('October 3, 2020', 'Main', 78));
console.log(m.toString());

m.newScreening('October 4, 2020', '235', `regular`);
m.newScreening('October 5, 2020', 'Main', `regular`);
m.newScreening('October 3, 2020', '235', `regular`);
m.newScreening('October 4, 2020', 'Main', `regular`);
console.log(m.toString());
