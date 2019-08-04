using System;
using MXGP.Models.Motorcycles.Classes;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;

namespace MXGP
{
    using Models.Motorcycles;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //TODO Add IEngine
            IMotorcycle varche = new PowerMotorcycle("12214235", 75);
            RiderRepository repo = new RiderRepository();
            repo.Add(varche);
            Console.WriteLine(String.Join(", ",repo.GetAll()));
            Motorcycle mto= (Motorcycle)repo.GetByName("12214235");
            Console.WriteLine(repo.Remove(varche));
            Console.WriteLine(String.Join(", ",repo.GetAll()));
        }
    }
}
