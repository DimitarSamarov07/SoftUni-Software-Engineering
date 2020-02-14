using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Controllers
{
    using System.Linq;
    using Data.ViewModels.Submissions;
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class SubmissionsController : Controller
    {
        private readonly SubmissionsService service = new SubmissionsService();

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            SubmissionCreateViewModel viewModel = new SubmissionCreateViewModel
            {
                ProblemId = id,
                Name = this.service.GetProblemName(id)
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            this.service.Create(problemId, code, this.User);

            return this.Redirect($"/Problems/Details?id={problemId}");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.service.Delete(id);

            return this.Redirect("/");
        }
    }
}
