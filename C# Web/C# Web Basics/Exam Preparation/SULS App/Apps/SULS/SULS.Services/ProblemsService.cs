using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    using System.Linq;

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

        public string GetProblemId(string name, int points)
        {
            throw new NotImplementedException();
        }

        public LoggedInViewModel GiveProblems()
        {
            var problems = db.Problems.Select(x => new IndexProblemViewModel
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
