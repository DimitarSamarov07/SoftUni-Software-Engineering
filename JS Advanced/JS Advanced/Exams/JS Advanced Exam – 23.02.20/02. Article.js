class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._likes = [];
        this._comments = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        } else if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`;
        } else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`;
        }
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error("You can't like the same article twice!")
        }
        if (this.creator === username) {
            throw new Error("You can't like your own articles!");
        }

        this._likes.push(username)
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error("You can't dislike this article!");
        }

        this._likes = this._likes.filter(user => user !== username);
        return `${username} disliked ${this.title}`
    }

    comment(username, content, id) {
        if (!id || !(this._comments.some(x => x.id === id))) {
            let newId;
            this._comments.length === 0 ? newId = 1 : newId = this._comments.length + 1;

            this._comments.push({id: newId, username, content, replies: []});

            return `${username} commented on ${this.title}`
        } else if (this._comments.some((comment) => comment.id === id)) {
            let returnMessage = '';
            this._comments.map(comment => {
                if (comment.id === id) {
                    let replyNewId;
                    comment.replies.length === 0
                        ? replyNewId = `${comment.id}.1`
                        : replyNewId = `${comment.id}.${comment.replies.length + 1}`;
                    // Replies should have the following structure:
                    comment.replies.push({id: replyNewId, username: username, content: content});
                    returnMessage = `You replied successfully`;
                }
            });
            return returnMessage;
        }
    }

    toString(sortingType) {

        const sorter = {
            "asc": (a, b) => a.id - b.id,
            "desc": (a, b) => b.id - a.id,
            "username": (a, b) => a.username.localeCompare(b.username)
        }

        const currSort = sorter[sortingType];
        let result = `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:\n`

        this._comments.sort(currSort)
            .forEach(({id, username, content, replies}) => {
                result += `-- ${id}. ${username}: ${content}\n`;

                if (replies.length > 0) {
                    replies.sort(currSort)
                        .forEach(({id, username, content}) => {
                            result += `--- ${id}. ${username}: ${content}\n`;
                        })
                }
            })

        return result.trim();
    }
}