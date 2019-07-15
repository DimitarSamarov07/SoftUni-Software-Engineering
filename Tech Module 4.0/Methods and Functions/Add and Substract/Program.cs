using System;

namespace Add_and_Substract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            

            SumOfTwoNumbers(firstNumber, secondNumber);
        }

        private static int  SumOfTwoNumbers(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            SubtractAndPrint(sum);
             return sum;
        }

        private static int SubtractAndPrint(int sum)
        {
            int thirdNumber = int.Parse(Console.ReadLine());
            int Substracted = sum - thirdNumber;
           Console.WriteLine(Substracted);
            return Substracted;
        }
    }
}
