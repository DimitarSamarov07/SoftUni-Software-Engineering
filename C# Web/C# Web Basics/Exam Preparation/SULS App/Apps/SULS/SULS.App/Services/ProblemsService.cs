namespace SULS.App.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.ViewModels.Home;
    using Models;

    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;

        public ProblemsService()
        {
            this.db = new SULSContext();
        }
        public void CreateProblem(string name, int points)
        {
            Problem problem = new Problem(name, points);
            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }


        public LoggedInViewModel GiveProblems()
        {
            var problems = this.db.Problems.Select(x => new IndexProblemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count(),
            })
                .ToArray();

            var loggedInViewModel = new LoggedInViewModel()
            {
                Problems = problems,
            };

            return loggedInViewModel;
        }
    }
}
