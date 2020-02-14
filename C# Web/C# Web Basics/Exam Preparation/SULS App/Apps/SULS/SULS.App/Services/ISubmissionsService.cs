namespace SULS.App.Services
{
    interface ISubmissionsService
    {
        void Create(string problemId, string code, string userId);

        string GetProblemName(string id);

        void Delete(string id);
    }
}
