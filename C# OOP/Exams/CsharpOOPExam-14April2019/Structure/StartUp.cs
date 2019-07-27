using System;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IFighter sth = new Fighter("PESHO", 12, 30);
            ITank sth2 = new Tank("Gosho", 303, 30);
            Pilot ivancho = new Pilot("Ivancho");
            ivancho.AddMachine(sth2);
            sth.Attack(sth2);
            ivancho.AddMachine(sth);
            Console.WriteLine(ivancho.Report());
            sth.ToggleAggressiveMode();
            sth2.ToggleDefenseMode();
            Console.WriteLine(ivancho.Report());
        }
    }
}