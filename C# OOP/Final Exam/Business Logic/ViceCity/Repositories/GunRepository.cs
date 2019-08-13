using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        public GunRepository()
        {
            models = new List<IGun>();
        }
        private List<IGun> models;

        public IReadOnlyCollection<IGun> Models => models;

        public void Add(IGun model)
        {
            if (models.Contains(model))
            {
                return;
            }
            models.Add(model);
        }
        //void Add(IGun model)
        //    •	Adds a gun in the collection.
        //•	If the gun already exists in the player's collection of guns, don't add it. 
        //•	Every gun is unique.

        public bool Remove(IGun model)
        {
            return models.Remove(model);
        }
        //bool Remove(IGun model)
        //    •	Removes a gun from the collection.

        public IGun Find(string name)
        {
            return models.Find(x => x.Name == name);
        }
        //IGun Find(string name)
        //    •	Returns a gun with that name. 
        //    It is guaranteed that the guns exists in the collection

    }
}
