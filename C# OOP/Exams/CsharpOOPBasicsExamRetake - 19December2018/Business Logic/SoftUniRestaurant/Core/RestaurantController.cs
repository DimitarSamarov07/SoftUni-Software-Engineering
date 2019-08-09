using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUniRestaurant.Core.Factories;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Core
{
    using System;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private FoodFactory Foodfact;
        private DrinkFactory Drinkfact;
        private TableFactory TableFact;
        private decimal income;

        public RestaurantController()
        {
            menu = new List<IFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            Foodfact = new FoodFactory();
            Drinkfact = new DrinkFactory();
            TableFact = new TableFactory();
            income = 0;
        }
        public string AddFood(string type, string name, decimal price)
        {
            IFood toAdd = Foodfact.MakeFood(type, name, price);
            menu.Add(toAdd);
            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink toAdd = Drinkfact.MakeDrink(type, name, servingSize, brand);
            drinks.Add(toAdd);
            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable toAdd = TableFact.MakeTable(type, tableNumber, capacity);
            tables.Add(toAdd);
            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable toReserve = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (toReserve == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            toReserve.Reserve(numberOfPeople);
            return $"Table {toReserve.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable tableOrder = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IFood foodToOrder = menu.FirstOrDefault(x => x.Name == foodName);
            if (tableOrder == null)
            {
                return $"Could not find table with {tableNumber}";
            }
            if (foodToOrder == null)
            {
                return $"No {foodName} in the menu";
            }
            tableOrder.OrderFood(foodToOrder);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable tableOrder = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink drinkToOrder = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (tableOrder == null)
            {
                return $"Could not find table with {tableNumber}";
            }
            if (drinkToOrder == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            tableOrder.OrderDrink(drinkToOrder);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {table.GetBill():f2}");
            income += table.GetBill();
            table.Clear();
            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(item.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in tables.Where(x => x.IsReserved))
            {
                sb.AppendLine(item.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {income:f2}lv";
        }
    }
}
