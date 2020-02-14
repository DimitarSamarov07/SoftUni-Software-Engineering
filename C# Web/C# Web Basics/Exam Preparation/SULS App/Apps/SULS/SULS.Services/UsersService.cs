using System;
using System.Text;

namespace SULS.Services
{
    using System.Linq;
    using System.Security.Cryptography;
    using Data;
    using Models;

    public class UsersService:IUsersService
    {
        private readonly SULSContext db = new SULSContext();

        public void CreateUser(string username, string email, string password)
        {
            User user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            password = Hash(password);

            return this.db.Users
                .Where(x => x.Username == username && x.Password == password)
                .Select(x=>x.Id)
                .FirstOrDefault();
        }

        public bool IsEmailUsed(string emailAddress)
        {
            return this.db.Users.Any(x => x.Email == emailAddress);
        }

        public bool IsUsernameUsed(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
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
