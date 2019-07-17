using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public interface ICitizen:IIdentifiable
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
