using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        public RaceRepository()
        {
            Models = new List<IRace>();
        }
        private List<IRace> Models { get; set; }
        public IRace GetByName(string name)
        {
            return Models.First(x => x.Name == name);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return Models.ToImmutableArray();
        }

        public void Add(IRace model)
        {
            Models.Add(model);
        }

        public bool Remove(IRace model)
        {
            return Models.Remove(model);
        }
    }
}
