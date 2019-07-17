using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{
    public interface IPet
    {
        string Name { get; set; }
        DateTime BirthDate { get; set; }
    }
}
