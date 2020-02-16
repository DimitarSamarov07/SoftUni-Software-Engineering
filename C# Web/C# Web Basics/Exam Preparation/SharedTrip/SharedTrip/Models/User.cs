namespace SharedTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SIS.MvcFramework;

    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserTrips = new HashSet<UserTrip>();
        }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
