import {toggleError, toggleInfo} from "../notifications.js";

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
}

export async function loginPost() {
    const email = this.params.email;
    const password = this.params.password;

    if (!email || !password) {
        toggleError(true, "Email and password cannot be empty!");
        return;
    }

    Backendless.UserService.login(email, password, true)
        .then((user) => {

            this.app.userData = {
                loggedIn: true,
                email: user.email,
                userId: user.objectId,
            }
            toggleInfo(true, "Login successful.");

            this.redirect("#/");

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
}

export async function registerPost() {
    const email = this.params.email;
    const password = this.params.password;
    const repeatPassword = this.params.repeatPassword;

    if (!email) {
        toggleError(true, "The email cannot be empty.");
        return;
    }

    if (password.length < 6) {
        toggleError(true, "The password should be at least 6 characters long.");
        return;
    }

    if (password !== repeatPassword) {
        toggleError(true, "Passwords do not match.");
        return;
    }

    const user = new Backendless.User();
    user.email = email;
    user.password = password;

    Backendless.UserService.register(user)
        .then(() => {
            toggleInfo(true, "Successful registration!")
            Backendless.UserService.login(email, password, true)
                .then((user) => {

                    this.app.userData = {
                        loggedIn: true,
                        email: user.email,
                        userId: user.objectId,
                    }

                    this.redirect("#/");

                })
                .catch(() => {
                    toggleError(true, "Invalid Login!");
                });
        })
        .catch(() => {
            toggleError("ERROR. Try again please"); //Server error or attempt to manipulate the data being send
        })
}

export async function logout() {
    Backendless.UserService.logout()
        .then(() => {
            this.app.userData = {
                loggedIn: false,
                email: null,
                userId: null,
            }
            toggleInfo(true, "Logout successful.")

            this.redirect("#/login")
        })
        .catch(err => {
            console.log(err)
        })
}