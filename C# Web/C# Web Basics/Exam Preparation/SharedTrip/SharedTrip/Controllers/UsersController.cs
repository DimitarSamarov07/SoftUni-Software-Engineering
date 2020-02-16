using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Net.Mail;
    using Services.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using ViewModels.Users;

    public class UsersController : Controller
    {
        //TODO: Check Security
        //TODO: Check Redirections

        private readonly IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service = service;
        }
        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
                //Logged users cannot access the page
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginViewModel model)
        {
            
            var id = this.service.GetUserId(model);

            if (id == null)
            {
                return this.View();
            }

            this.SignIn(id);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
                //Logged users cannot access the page
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserViewModel model)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (model.Username?.Length < 5 || model.Username?.Length > 20)
            {
                return this.View();
            }

            if (model.Email == null || !this.IsEmailValid(model.Email))
            {
                return this.View();
            }

            if (model.Password?.Length < 6 || model.Password?.Length > 20)
            {
                return this.View();
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.View();
            }

            this.service.CreateUser(model);

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

        private bool IsEmailValid(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
