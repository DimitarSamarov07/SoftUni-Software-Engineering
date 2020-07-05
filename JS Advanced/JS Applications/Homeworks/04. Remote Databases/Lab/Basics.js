async function basics() {
    module.exports.auth = require("firebase/auth")

    const fetch = require("node-fetch")
    const firebase = require("firebase/app")
    let firebaseConfig = {
        apiKey: "AIzaSyA0GkjSHnqeemv0A4dhUB6rNxQe-OiZBoI",
        authDomain: "softunihomeworks.firebaseapp.com",
        databaseURL: "https://softunihomeworks.firebaseio.com",
        projectId: "softunihomeworks",
        storageBucket: "softunihomeworks.appspot.com",
        messagingSenderId: "1058977324946",
        appId: "1:1058977324946:web:853ffe5d30ee18c5d16b4b"
    };
    // Initialize Firebase
    firebase.initializeApp(firebaseConfig);

    async function getBook(id) {
        const baseUrl = `https://softunihomeworks.firebaseio.com/Books/${id}.json`
        const book = await fetch(baseUrl).then(data => data.json());

        console.log(book);
    }

    async function createBook(title, author) {
        const baseUrl = "https://softunihomeworks.firebaseio.com/Books.json";
        const objToPost = {title, author};

        await fetch(baseUrl, {
            method: "POST",
            body: JSON.stringify(objToPost),
        })
    }

    async function patchBook(title, author) {
        const baseUrl = "https://softunihomeworks.firebaseio.com/Books.json";
        const objToPost = {title, author};

        await fetch(baseUrl, {
            method: "PATCH",
            body: JSON.stringify(objToPost),
        })
    }

    async function changeBookAuthor(newAuthor) {
        const baseUrl = "https://softunihomeworks.firebaseio.com/Books/1/author.json";

        const response = await fetch(baseUrl, {
            method: "PUT",
            body: JSON.stringify(newAuthor),
        })

        console.log(response);
    }

    async function createUser(email, password) {

        const result = await firebase.auth().createUserWithEmailAndPassword(email, password)
            .catch((error) => {
                // Handle Errors here.
                let errorCode = error.code;
                let errorMessage = error.message;
                console.log(`Firebase says: ${errorCode}(${errorMessage})`);
            });

        console.log(result);

    }

    async function loginUser(email, password) {
        const result = await firebase.auth().signInWithEmailAndPassword(email, password)
            .catch((error) => {
                // Handle Errors here.
                let errorCode = error.code;
                let errorMessage = error.message;
                console.log(`Firebase says: ${errorCode}(${errorMessage})`);
            });

        console.log(result);
    }

    async function logoutUser() {
        const result = await firebase.auth().signOut()
            .then(() => {
                // Sign-out successful.
            })
            .catch((error) => {
                // Handle Errors here.
                let errorCode = error.code;
                let errorMessage = error.message;
                console.log(`Firebase says: ${errorCode}(${errorMessage})`);
            });

        console.log(result);
    }
}

basics();