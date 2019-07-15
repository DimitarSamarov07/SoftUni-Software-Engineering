using System;


namespace Factorial_Devision
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());


            double firstFactorial = GetFactorial(firstNumber);
            double secondFactorial = GetFactorial(secondNumber);
            double finalResult = firstFactorial / secondFactorial;
            Console.WriteLine($"{finalResult:f2}");
        }

        private static double GetFactorial(double number)
        {
            double factorial = 1;

            for (double i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
