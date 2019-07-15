using System;

namespace Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();
            DateModifier dates = new DateModifier(start,end);

            double result = dates.GetDifference();

            if (result<0)
            {
                result = result * -1;
                Console.WriteLine(result);
            }

            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
