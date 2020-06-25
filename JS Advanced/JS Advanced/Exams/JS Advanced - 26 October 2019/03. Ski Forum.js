class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
    }

    register(username, password, repeatPassword, email) {
        if (username === "" || password === "" || repeatPassword === "" || email === "") {
            throw new Error("Input can not be empty")
        } else if (password !== repeatPassword) {
            throw new Error("Passwords do not match");
        } else if (this._users.find(x => x.username === username)) {
            throw new Error("This user already exists!");
        }

        this._users.push({username, password, email, isLoggedIn: false});

        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password) {
        const user = this._users.find(x => x.username === username);

        if (!user) {
            throw new Error("There is no such user");
        }

        if (user.password === password) {
            user.isLoggedIn = true;
            return "Hello! You have logged in successfully";
        }

    }

    logout(username, password) {
        const user = this._users.find(x => x.username === username);

        if (!user) {
            throw new Error("There is no such user");
        }

        if (user.password === password) {
            user.isLoggedIn = false;
            return "You have logged out successfully";
        }

    }

    postQuestion(username, question) {
        const user = this._users.find(x => x.username === username);
        if (!user || (user.isLoggedIn === false)) {
            throw new Error("You should be logged in to post questions");
        }

        if (!question) {
            throw new Error("Invalid question");
        }

        this._questions.push({id: this._id, username, question, answers: []});
        this._id += 1;
        return "Your question has been posted successfully";
    }

    postAnswer(username, questionId, answer) {
        let user = this._users.find(x => x.username === username);
        if ((!user) || (user.isLoggedIn === false)) {
            throw new Error("You should be logged in to post answers");
        }
        if (!answer) {
            throw new Error("Invalid answer");
        }
        let question = this._questions.find(x => x.id === questionId);
        if (!question) {
            throw new Error("There is no such question");
        }

        let answerObj = {
            username: username,
            answer: answer,
        };

        question.answers.push(answerObj);

        return "Your answer has been posted successfully";
    }

    showQuestions() {
        return this._questions.reduce((acc, {id, username, question, answers}) => {
            acc += `Question ${id} by ${username}: ${question}\n`

            acc += answers.reduce((acc, {username, answer}) => {
                return acc += `---${username}: ${answer}\n`;
            }, "")

            return acc;
        }, "")
            .trim()
    }
}