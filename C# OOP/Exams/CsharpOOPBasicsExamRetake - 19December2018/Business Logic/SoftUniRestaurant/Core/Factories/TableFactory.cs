using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Tables;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Core.Factories
{
    public class TableFactory
    {
        public ITable MakeTable(string type,int tableNumber,int capacity)
        {
            if (type=="Inside")
            {
                return new InsideTable(tableNumber,capacity);
            }
            if (type=="Outside")
            {
                return new OutsideTable(tableNumber,capacity);
            }

            return null;
        }
    }
}
