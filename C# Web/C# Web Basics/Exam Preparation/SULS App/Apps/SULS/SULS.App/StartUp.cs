namespace SULS.App
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            using (var db = new SULSContext())
            {
                db.Database.Migrate();
            }
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            
        }
    }
}