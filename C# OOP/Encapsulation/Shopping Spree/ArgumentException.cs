using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Shopping_Spree
{
    public class ArgumentException
    {
        public const string MoneyException = "Money cannot be negative";
        public const string NameException = "Name cannot be empty";
        public  string OutOfMoneyException = "{0} can't afford {1}";

        public ArgumentException()
        {
            
        }
        public ArgumentException(string type)
        {
            if (type == "money")
            {
                Console.WriteLine(MoneyException);
                Environment.Exit(0);
            }

            else if (type == "name")
            {
                Console.WriteLine(NameException);
                Environment.Exit(0);
            }



        }

        public ArgumentException(string personName, string product)
        {

        }
    }
}
