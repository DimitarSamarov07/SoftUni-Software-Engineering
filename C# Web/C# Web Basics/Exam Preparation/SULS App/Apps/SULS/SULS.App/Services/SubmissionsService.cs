using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Services
{
    using System.Linq;
    using Models;

    public class SubmissionsService:ISubmissionsService
    {
        private readonly SULSContext db = new SULSContext();

        public void Create(string problemId, string code, string userId)
        {
            var submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                CreatedOn = DateTime.Now
            };

            this.db.Submissions.Add(submission);
            Random random = new Random();
            int maxPoints = this.db.Problems.First(x => x.Id == problemId).Points;
            submission.AchievedResult = random.Next(0, maxPoints+1);
            this.db.SaveChanges();
        }

        public string GetProblemName(string id)
        {
            return this.db.Problems.First(x => x.Id == id).Name;
        }

        public void Delete(string id)
        {
            var item = this.db.Submissions.First(x => x.Id == id);
            this.db.Submissions.Remove(item);
            this.db.SaveChanges();
        }
    }
}
