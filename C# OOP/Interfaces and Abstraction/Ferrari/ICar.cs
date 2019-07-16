using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface ICar
    { 
        string Driver { get; set; }
        string Gas();
        string Brake();
        string Model { get;}
    }
}
