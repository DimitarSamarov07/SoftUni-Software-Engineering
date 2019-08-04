using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Classes;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class Repository : IRepository<object>
    {
        public Repository()
        {
            Models=new List<object>();
        }

        public List<object> Models { get; set; }
        public object GetByName(string name)
        {
            if (Models.Any(x => x.GetType().BaseType == typeof(Motorcycle)))
            {
                List<object> machines = Models.Where(x => x.GetType().BaseType == typeof(Motorcycle)).ToList();
                List<Motorcycle> blahBlah = new List<Motorcycle>();
                foreach (Motorcycle machine in machines)
                {
                    blahBlah.Add(machine);
                }
                if (blahBlah.Any(x => x.Model == name))
                {
                    return blahBlah.FirstOrDefault(x => x.Model == name);
                }
            }

            if (Models.Any(x => x.GetType().BaseType == typeof(Rider)))
            {
                List<object> machines = Models.Where(x => x.GetType().BaseType == typeof(Rider)).ToList();
                List<Rider> blahBlah = new List<Rider>();
                foreach (Rider machine in machines)
                {
                    blahBlah.Add(machine);
                }
                if (blahBlah.Any(x => x.Name == name))
                {
                    return blahBlah.FirstOrDefault(x => x.Name == name);
                }
            }

            if (Models.Any(x => x.GetType().BaseType == typeof(Race)))
            {
                List<object> machines = Models.Where(x => x.GetType().BaseType == typeof(Race)).ToList();
                List<Race> blahBlah = new List<Race>();
                foreach (Race machine in machines)
                {
                    blahBlah.Add(machine);
                }
                if (blahBlah.Any(x => x.Name == name))
                {
                    return blahBlah.FirstOrDefault(x => x.Name == name);
                }
            }
            return new object();
        }

        public IReadOnlyCollection<object> GetAll()
        {
            return Models;
        }

        public void Add(object model)
        {
            Models.Add(model);
        }

        public bool Remove(object model)
        {
            return Models.Remove(model);
        }
    }
}
