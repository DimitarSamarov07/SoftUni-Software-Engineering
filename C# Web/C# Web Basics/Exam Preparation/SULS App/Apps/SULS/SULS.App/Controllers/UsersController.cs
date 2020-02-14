namespace SULS.App.Controllers
{
    using System;
    using System.Net.Mail;
    using Data.ViewModels.Users;
    using Microsoft.Extensions.Logging;
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        private readonly IUsersService service;

        public UsersController(UsersService service)
        {
            this.service = service;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            string id = this.service.GetUserId(username, password);

            if (string.IsNullOrEmpty(id))
            {
                return this.Error("Wrong credentials!");
            }

            this.SignIn(id);
            return Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("The passwords don't match!");
            }

            else if (model.Password?.Length < 6 || model.Password?.Length > 20)
            {
                return this.Error("The password length should be in the range 6-20 characters!");
            }

            else if (model.Username?.Length < 5 || model.Username?.Length > 20)
            {
                return this.Error("The username length should be in the range 5-20 characters!");
            }

            else if (!IsValidEmail(model.Email))
            {
                return this.Error("You should enter a valid email address!");
            }

            else if (this.service.IsEmailUsed(model.Email))
            {
                return this.Error("Email is already used by another user!");
            }

            else if (this.service.IsUsernameUsed(model.Username))
            {
                return this.Error("Username is already used by another user!");
            }

            this.service.CreateUser(model.Username, model.Email, model.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            this.SignOut();

            return this.Redirect("/");
        }

        private bool IsValidEmail(string modelEmail)
        {
            try
            {
                new MailAddress(modelEmail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}