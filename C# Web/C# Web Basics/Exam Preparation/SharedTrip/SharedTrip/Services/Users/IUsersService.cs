using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Users
{
    using ViewModels.Users;

    public interface IUsersService
    {
        void CreateUser(RegisterUserViewModel model);

        string GetUserId(LoginViewModel model);
    }
}
