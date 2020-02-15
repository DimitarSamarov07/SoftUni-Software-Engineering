namespace Andreys.App.Controllers
{
    using Andreys.Controllers;
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly ProductsService service = new ProductsService();

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.View(this.service.GetAll(),"Home");
            }
            return this.View();
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
