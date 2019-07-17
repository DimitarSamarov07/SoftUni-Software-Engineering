using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{
    public interface IRobot:IIdentifiable
    {
        string Model { get; set; }
    }
}
