
export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        loginForm: await this.load('./templates/login/loginForm.hbs')
    };


    this.partial('./templates/login/loginPage.hbs', this.app.userData)
        .then(() => {
            $("#loginForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => {
            // toggleLoading(false);
        });
}

export async function loginPost() {
    const email = this.params.email;
    const password = this.params.password;

    if (!email || !password) {
        return ;
        // toggleError(true, "Email and password cannot be empty!");
        // toggleLoading(false);
    }

    Backendless.UserService.login(email, password, true)
        .then((user) => {

            this.app.userData = {
                loggedIn: true,
                email: user.email,
                userId: user.objectId,
            }
            // toggleLoading(false);
            // toggleInfo(true, "Login successful.");

            // setTimeout(function () {
                this.redirect("#/");
            // }.bind(this), 1200);

        })
        .catch(() => {
            // toggleError(true, "Invalid Login!");
        });
}

export async function registerGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        registerForm: await this.load('./templates/register/registerForm.hbs')
    };

    this.partial('./templates/register/registerPage.hbs')
        .then(() => {
            $("#registerForm").submit(function (e) {
                e.preventDefault();
            });
        })
        .then(() => {
            // toggleLoading(false);
        });
}

export async function registerPost() {
    const email = this.params.email;
    const password = this.params.password;
    const repeatPassword = this.params.repeatPassword;

    if (password !== repeatPassword){
        return ;
    }
    const user = new Backendless.User();
    user.email = email;
    user.password = password;

    Backendless.UserService.register(user)
        .then(() => {
            // toggleLoading(false);
            // toggleInfo(true, "User registration successful.")
            // setTimeout(function () {
                this.redirect("#/login")
            // }.bind(this), 1000)
        })
        .catch(() => {
            // toggleLoading(false);
            // toggleError("ERROR. Try again please"); //Server error or attempt to manipulate the data being send
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
            // toggleLoading(false);
            // toggleInfo(true,"Logout successful.")

            // setTimeout(function () {
                this.redirect("#/")
            // }.bind(this), 1000)
        })
        .catch(err =>{
            console.log(err)
        })
}