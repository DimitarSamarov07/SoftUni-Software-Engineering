using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string password, string email);

        string GetUserId(string username, string password);
    }
}
