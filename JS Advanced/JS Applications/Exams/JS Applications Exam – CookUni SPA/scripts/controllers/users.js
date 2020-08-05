import {toggleError, toggleInfo, toggleLoading} from "../notifications.js";

export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };


    this.partial('./templates/login/loginPage.hbs', this.app.userData)
        .then(() => {
            $("#loginForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => {
            toggleLoading(false);
        });
}

export async function loginPost() {
    toggleLoading(true);
    const username = this.params.username;
    const password = this.params.password;

    if (!username || !password) {
        toggleError(true, "Username and password cannot be empty!");
        toggleLoading(false);
    }

    Backendless.UserService.login(username, password, true)
        .then((user) => {

            this.app.userData = {
                loggedIn: true,
                username: user.username,
                userId: user.objectId,
                firstName: user.firstName,
                lastName: user.lastName,
            }
            toggleLoading(false);
            toggleInfo(true, "Login successful.");

            setTimeout(function () {
                this.redirect("#/");
            }.bind(this), 1200);

        })
        .catch(() => {
            toggleError(true, "Invalid Login!");
        });
}

export async function registerGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial('./templates/register/registerPage.hbs')
        .then(() => {
            $("#registerForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => {
            toggleLoading(false);
        });
}

export async function registerPost() {
    const {firstName, lastName, username, password, repeatPassword} = this.params;

    if (firstName.length < 2) {
        toggleError(true, "The first name should be at least 2 characters long");
        toggleLoading(false);
        return;
    }

    if (lastName.length < 2) {
        toggleError(true, "The last name should be at least 2 characters long");
        toggleLoading(false);
        return;
    }

    if (username.length < 3) {
        toggleError(true, "The username should be at least 3 characters long");
        toggleLoading(false);
        return;
    }

    if (password.length < 6) {
        toggleError(true, "The password should be at least 6 characters long");
        toggleLoading(false);
        return;
    }

    if (password !== repeatPassword) {
        toggleError(true, "Passwords do not match!");
        toggleLoading(false);
        return;
    }

    const user = new Backendless.User();
    user.firstName = firstName;
    user.lastName = lastName;
    user.username = username;
    user.password = password;

    Backendless.UserService.register(user)
        .then(() => {
            toggleLoading(false);
            toggleInfo(true, "User registration successful.")
            setTimeout(function () {
                this.redirect("#/login")
            }.bind(this), 1000)
        })
        .catch(() => {
            toggleLoading(false);
            toggleError("The username is already taken.");
        })
}

export async function logout() {
    Backendless.UserService.logout()
        .then(() => {
            this.app.userData = {
                loggedIn: false,
                username: null,
                userId: null,
            }
            toggleLoading(false);
            toggleInfo(true, "Logout successful.")

            setTimeout(function () {
                this.redirect("#/")
            }.bind(this), 1000)
        })
        .catch(err => {
            console.log(err)
        })
}