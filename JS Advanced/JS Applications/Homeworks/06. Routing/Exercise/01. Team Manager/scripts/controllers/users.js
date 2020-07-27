import {toggleError, toggleInfo} from "../notifications.js";
import {getUserTeam, getTeam} from "../data.js";

export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loginForm: await this.load('./templates/login/loginForm.hbs')
    };


    this.partial('./templates/login/loginPage.hbs', this.app.userData)
        .then(() =>{
            $("#loginForm").submit(function(e) {
                e.preventDefault();
            });
        });
}

export async function loginPost() {
    const username = this.params.username;
    const password = this.params.password;

    if (!username || !password) {
        toggleError(true, "Username and password cannot be empty!");
    }

    Backendless.UserService.login(username, password, true)
        .then((user) =>{
           getUserTeam(user.objectId)
                .then((team) =>{
                    this.app.userData = {
                        loggedIn: true,
                        username: user.username,
                        userId: user.objectId,
                        teamId: team.objectId,
                        hasTeam: team.length > 0,
                    }
                    toggleInfo(true, "Login successful!!");

                    setTimeout(function () {
                        this.redirect("#/home");
                    }.bind(this), 1200);
                });

        })
        .catch(() => {
            toggleError(true, "Invalid Login!");
        });
}

export async function registerGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        registerForm: await this.load('./templates/register/registerForm.hbs')
    };

    this.partial('./templates/register/registerPage.hbs')
        .then(() =>{
            $("#registerForm").submit(function(e) {
                e.preventDefault();
            });
        });
}

export async function registerPost() {
    const username = this.params.username;
    const password = this.params.password;
    const repeatPassword = this.params.repeatPassword;

    if (password !== repeatPassword){
        toggleError(true, "Passwords do not match!");
    }

    const user = new Backendless.User();
    user.username = username;
    user.password = password;

    Backendless.UserService.register(user)
        .then(this.app.redirect("#/login"))
        .catch(err =>{
            toggleError("ERROR. Try again please");
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

            toggleInfo(true,"Logout successful!")

            setTimeout(function () {
                this.redirect("#/home")
            }.bind(this), 1000)
        })
        .catch(err =>{
            console.log(err)
        })
}