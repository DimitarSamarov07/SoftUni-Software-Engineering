export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loginForm: await this.load('./templates/login/loginForm.hbs')
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
        return;
    }

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

        });
}

export async function registerGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        registerForm: await this.load('./templates/register/registerForm.hbs')
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

    if (password !== repeatPassword) {
        return;
    }

    const user = new Backendless.User();
    user.email = email;
    user.password = password;

    Backendless.UserService.register(user)
        .then(() => {
            this.redirect("#/login")
        })
        .catch(() => {

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

            this.redirect("#/")

        })
        .catch(err => {
            console.log(err)
        })
}