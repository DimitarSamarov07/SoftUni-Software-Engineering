using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);

            Vehicle car = new Car(carFuelQuantity,carFuelConsumption);
            Vehicle truck = new Truck(truckFuelQuantity,truckFuelConsumption);
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                string command = line[0];
                string type = line[1];
                if (command=="Drive")
                {
                    double km = double.Parse(line[2]);
                    if (type=="Car")
                    {
                        Console.WriteLine(car.Drive(km));
                    }

                    else if(type=="Truck")
                    {
                        Console.WriteLine(truck.Drive(km));
                    }
                }

                else if(command=="Refuel")
                {
                    double quantity = double.Parse(line[2]);

                    if (type=="Car")
                    {
                        car.Refuel(quantity);
                    }

                    else if (type=="Truck")
                    {
                        truck.Refuel(quantity);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);

        }
    }
}
