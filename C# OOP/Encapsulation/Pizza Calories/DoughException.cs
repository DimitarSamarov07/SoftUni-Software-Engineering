using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Calories
{
    public class DoughException:Exception
    {
        public const string InvalidType = "Invalid type of dough.";
        public const string InvalidWeight ="Dough weight should be in the range [1..200].";

        public DoughException(string type)
        {
            if (type=="typeWrong")
            {
                Console.WriteLine(InvalidType);
                Environment.Exit(0);
            }

            else if (type =="gramsOverflow")
            {
                Console.WriteLine(InvalidWeight);
                Environment.Exit(0);
            }
        }
    }
}
