namespace SharedTrip
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Services.Trips;
    using Services.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using ViewModels.Trips;

    public class Startup : IMvcApplication
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public void Configure(IList<Route> routeTable)
        {
           this.db.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService,UsersService>();
            serviceCollection.Add<ITripsServices,TripsServices>();
        }
    }
}
