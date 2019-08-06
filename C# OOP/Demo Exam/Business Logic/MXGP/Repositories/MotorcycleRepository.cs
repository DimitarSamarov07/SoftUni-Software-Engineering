using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using MXGP.Models.Motorcycles.Classes;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository:IRepository<IMotorcycle>
    {
        private List<IMotorcycle> Models { get; set; }=new List<IMotorcycle>();

        public IMotorcycle GetByName(string name)
        {
            return Models.First(x => x.Model == name);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return Models.ToImmutableArray();
        }

        public void Add(IMotorcycle model)
        {
            Models.Add(model);
        }

        public bool Remove(IMotorcycle model)
        {
            return Models.Remove(model);
        }
    }
}
