﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    using System.Linq;
    using System.Security.Cryptography;
    using Data;
    using Models;

    public class UsersService : IUsersService
    {
        private readonly AndreysDbContext db = new AndreysDbContext();

        public void CreateUser(string username, string password, string email)
        {
            var user = new User()
            {
                Username = username,
                Password = this.Hash(password),
                Email = email
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            password = this.Hash(password);
            User user = this.db.Users
                .FirstOrDefault(x => x.Username == username && x.Password == password);

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
