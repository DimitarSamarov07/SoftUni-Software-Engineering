namespace SULS.App.Controllers
{
    using System.Linq;
    using Data.ViewModels;
    using Data.ViewModels.Problems;
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ProblemsController : Controller
    {
        private readonly SULSContext db = new SULSContext();
        private readonly IProblemsService service;

        public ProblemsController(ProblemsService service)
        {
            this.service = service;
        }
        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (name?.Length < 5 || name?.Length > 20)
            {
                return this.Error("Name length should be in the range 5-20 characters!");
            }

            if (points < 50 || points > 300)
            {
                return this.Error("Points should be in range 50-300");
            }

            this.service.CreateProblem(name, points);

            return this.Redirect("/");
        }


        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.db.
                Problems.
                Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                {
                    Name = x.Name,
                    Problems = x.Submissions.Select(s =>
                        new ProblemDetailsSubmissionViewModel
                        {
                            CreatedOn = s.CreatedOn,
                            AchievedResult = s.AchievedResult,
                            SubmissionId = s.Id,
                            MaxPoints = x.Points,
                            Username = s.User.Username,
                        })
                }).FirstOrDefault();

            return this.View(viewModel);
        }
    }
}
