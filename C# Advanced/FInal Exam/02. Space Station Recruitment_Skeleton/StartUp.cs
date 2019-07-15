using System;

namespace SpaceStationRecruitment
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the repository
            SpaceStation spaceStation = new SpaceStation("Apolo", 2);
            //Initialize entity
            Astronaut astronaut1 = new Astronaut("Ivan", 400, "Bulgaia");
            Astronaut astronaut2 = new Astronaut("Stephen", 4, "Bulgaria");
            Astronaut astronaut3 = new Astronaut("johny", 0, "Bulgria");
            //Print Astronaut
             //Astronaut: Stephen, 40 (Bulgaria)

            //Add Astronaut
            spaceStation.Add(astronaut1);
            spaceStation.Add(astronaut2);
            spaceStation.Add(astronaut3);
            Console.WriteLine(spaceStation.Report());
            //Remove Ast

        }
    }
}
