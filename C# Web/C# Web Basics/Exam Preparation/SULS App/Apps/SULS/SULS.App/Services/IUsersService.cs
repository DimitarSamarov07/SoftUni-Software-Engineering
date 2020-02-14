namespace SULS.App.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsEmailUsed(string emailAddress);

        bool IsUsernameUsed(string username);

    }
}
