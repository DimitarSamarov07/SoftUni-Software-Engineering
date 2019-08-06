using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository:IRepository<IRider>
    {
        private List<IRider> Models { get; set; }=new List<IRider>();
        public IRider GetByName(string name)
        {
            return Models.First(x => x.Name == name);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return Models.ToImmutableArray();
        }

        public void Add(IRider model)
        {
            Models.Add(model);
        }

        public bool Remove(IRider model)
        {
            return Models.Remove(model);
        }
    }
}
