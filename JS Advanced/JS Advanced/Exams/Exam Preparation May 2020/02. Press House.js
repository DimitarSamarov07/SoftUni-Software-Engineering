function pressHouse() {
    class Article {

        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Title: ${this.title}\n`
                + `Content: ${this.content}`
        }
    }

    class ShortReports extends Article {

        constructor(title, content, originalResearches) {
            if (content.length > 150) {
                throw new Error("Short reports content should be less then 150 symbols.");
            }

            if (!originalResearches["title"] || !originalResearches["author"]) {
                throw new Error("The original research should have author and title.");
            }
            super(title, content);
            this.originalResearches = originalResearches;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
            return "The comment is added.";
        }

        toString() {
            const result = super.toString()
                + `\nOriginal Research: ${this.originalResearches.title} by ${this.originalResearches.author}\n`

            if (this.comments.length > 0) {
                return result + "Comments:\n"
                    + this.comments.reduce((acc, curr) => {
                        return acc += curr + "\n";
                    }, "")
                        .trimEnd();
            }

            return result.trimEnd();
        }
    }

    class BookReview extends Article {
        constructor(title, content, book) {
            super(title, content);
            this.book = book;
            this.clients = [];
        }

        addClient(clientName, orderDescription) {
            if (this.clients.filter(x => x.clientName === clientName).length > 0) {
                throw new Error("This client has already ordered this review.");
            }

            this.clients.push({clientName, orderDescription})

            return `${clientName} has ordered a review for ${this.book.name}`
        }

        toString() {
            const result = super.toString()
                + `\nBook: ${this.book.name}\n`;

            if (this.clients.length > 0) {
                return result + "Orders:\n"
                    + this.clients.reduce((acc, {clientName, orderDescription}) => {
                        return acc += `${clientName} - ${orderDescription}\n`;
                    }, "")
                        .trimEnd();
            }

            return result.trimEnd();
        }
    }

    return {
        Article,
        ShortReports,
        BookReview
    }
}

