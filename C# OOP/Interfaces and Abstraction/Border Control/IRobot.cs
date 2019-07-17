using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public interface IRobot:IIdentifiable
    {
        string Model { get; set; }
    }
}
