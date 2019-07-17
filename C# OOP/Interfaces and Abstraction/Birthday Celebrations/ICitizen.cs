using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{
    public interface ICitizen:IIdentifiable
    {
        string Name { get; set; }
        int Age { get; set; }
        DateTime BirthDate { get; set; }
    }
}
