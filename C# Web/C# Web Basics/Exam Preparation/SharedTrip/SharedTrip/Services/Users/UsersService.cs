using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Users
{
    using System.Linq;
    using System.Security.Cryptography;
    using Models;
    using ViewModels.Users;

    public class UsersService:IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService()
        {
            this.db = new ApplicationDbContext();
        }

        public void CreateUser(RegisterUserViewModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.Hash(model.Password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(LoginViewModel model)
        {
            var user = this.db.Users.FirstOrDefault(x =>
                x.Username == model.Username && x.Password == this.Hash(model.Password));

            return user?.Id;
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
