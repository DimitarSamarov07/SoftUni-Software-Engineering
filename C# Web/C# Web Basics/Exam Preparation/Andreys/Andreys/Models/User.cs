using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Models
{
    using System.ComponentModel.DataAnnotations;
    using SIS.MvcFramework;

    public class User:IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
