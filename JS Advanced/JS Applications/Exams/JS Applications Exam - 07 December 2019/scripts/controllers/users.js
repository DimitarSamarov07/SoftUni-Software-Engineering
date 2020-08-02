import {toggleError, toggleInfo, toggleLoading} from "../notifications.js";
import {getFullUserProfile} from "../data.js";

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
    const username = this.params.username;
    const password = this.params.password;
    const repeatPassword = this.params.repeatPassword;

    if (password !== repeatPassword) {
        toggleError(true, "Passwords do not match!");
        toggleLoading(false);
        return;
    }

    const user = new Backendless.User();
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
            toggleError("ERROR. Try again please"); //Server error or attempt to manipulate the data being send
        })
}

export async function getUserProfile() {
    const {userId} = this.params;
    const user = await getFullUserProfile(userId);
    user.displayName = user.username;
    delete user.username;

    const context = Object.assign({}, user, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial("./templates/profile/profilePage.hbs", context)
        .then(() => toggleLoading(false))

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
            toggleInfo(true,"Logout successful.")

            setTimeout(function () {
                this.redirect("#/")
            }.bind(this), 1000)
        })
        .catch(err =>{
            console.log(err)
        })
}