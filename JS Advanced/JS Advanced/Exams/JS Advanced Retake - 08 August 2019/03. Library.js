class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: libraryName.length,
            special: libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER,
        }
    }

    subscribe(name, type) {
        if (!this.subscriptionTypes.hasOwnProperty(type)) {
            throw new Error(`The type ${type} is invalid`)
        }
        if (this.subscribers.some(x => x.name === name)) {
            const subscriber = this.subscribers.find(x => x.name === name);
            subscriber.type = type;
            return subscriber;
        }

        const subscriber = {
            name,
            type,
            books: []
        }

        this.subscribers.push(subscriber);

        return subscriber;

    }

    unsubscribe(name) {
        const subscriber = this.subscribers.find(x => x.name === name);

        if (!subscriber) {
            throw new Error(`There is no such subscriber as ${name}`)
        }

        this.subscribers.splice(this.subscribers.indexOf(subscriber), 1);

        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        const subscriber = this.subscribers.find(x => x.name === subscriberName);

        if (!subscriber) {
            throw new Error(`There is no such subscriber as ${subscriberName}`);
        }

        if (subscriber.books.length + 1 > this.subscriptionTypes[subscriber.type]) {
            throw new Error(`You have reached your subscription limit ${this.subscriptionTypes[subscriber.type]}!`);
        }

        subscriber.books.push({title: bookTitle, author: bookAuthor});

        return subscriber;
    }

    showInfo() {
        if (this.subscribers.length > 0) {
            return this.subscribers.reduce((acc, {name, type, books}) => {
                acc += `Subscriber: ${name}, Type: ${type}\n`;

                const booksResults = books.map(x => `${x.title} by ${x.author}`)
                acc += "Received books: " + booksResults.join(", ") + "\n";

                return acc;
            }, "");
        }

        return `${this.libraryName} has no information about any subscribers`

    }
}

let lib = new Library('Lib');

lib.subscribe('John', 'special');
lib.subscribe('John', 'normal');
console.log(lib.showInfo());