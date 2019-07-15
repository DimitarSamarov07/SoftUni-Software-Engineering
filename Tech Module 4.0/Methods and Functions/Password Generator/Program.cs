using System;
namespace Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string password = Console.ReadLine();
            int d = password.Length;
            int f = d;
            int numberOfDigits = 0;
            int unususable = 0;
            bool isValid = true;

            //check for Lenght
            if (f < 6 || f > 10)
            {

                Console.WriteLine("Password must be between 6 and 10 " +
                    "characters");
                isValid = false;
            }

            //check for special symbols
            for (int i = 0; i < f; i++)
            {
                bool special = char.IsLetterOrDigit(password[i]);
                if (password[i]==' ')
                {
                    unususable++;
                }
                if (special == false)
                {
                    unususable++;
                    isValid = false;
                }

            }

            //check for digits
            for (int i = 0; i < f; i++)
            {
                bool number = char.IsDigit(password[i]);

                if (number == true)
                {
                    numberOfDigits++;
                    
                }
            }


            //Write results
            

            if (unususable > 0)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (numberOfDigits < 2)
            {
                isValid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }
            
            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }

        }

        




    }

}