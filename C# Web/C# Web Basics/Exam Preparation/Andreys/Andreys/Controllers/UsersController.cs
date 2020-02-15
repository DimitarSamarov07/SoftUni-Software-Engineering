using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Controllers
{
    using System.Net.Mail;
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
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
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            string id = this.service.GetUserId(username, password);
            if (id==null)
            {
                return this.Error("Wrong credentials!");
            }

            this.SignIn(id);
            return this.Redirect("/");
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
        public HttpResponse Register(string username, string email, string password, string confirmPassword)
        {
            if (username?.Length < 4 || username?.Length > 20)
            {
                return this.Error("The name length should be in range 4-20 characters!");
            }

            if (password?.Length < 6 || password?.Length > 20)
            {
                return this.Error("Password length should be in range 6-20 characters!");
            }

            if (password != confirmPassword)
            {
                return this.Error("Passwords don't match!");
            }

            if (!IsEmailValid(email))
            {
                return this.Error("The email is invalid!");
            }

            this.service.CreateUser(username,password,email);

            return this.Redirect("/Users/Login");
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                MailAddress address = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
