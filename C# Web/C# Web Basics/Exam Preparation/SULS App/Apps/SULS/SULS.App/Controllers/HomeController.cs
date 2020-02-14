namespace SULS.App.Controllers
{
    using System;
    using Data.ViewModels.Home;
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController:Controller
    {
        private readonly SULSContext db = new SULSContext();
        private readonly ProblemsService problemsService = new ProblemsService();
        

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.View(this.problemsService.GiveProblems(),"IndexLoggedIn");
            }

            var viewModel = new IndexViewModel
            {
                Message = "Welcome to SULS Platform!",
                Year = DateTime.UtcNow.Year
            };

            return this.View(viewModel);
        }

        
    }
}