using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable

    {
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;

        private Table()
        {
            FoodOrders = new List<IFood>();
            DrinkOrders = new List<IDrink>();
        }

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        : this()
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        private List<IFood> FoodOrders;
        private List<IDrink> DrinkOrders;
        public int TableNumber
        {
            get => tableNumber;
            private set => tableNumber = value;
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get => pricePerPerson;
            private set => pricePerPerson = value;
        }

        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get { return decimal.Parse($"{PricePerPerson * NumberOfPeople:f2}"); }
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }

        public void OrderFood(IFood food)
        {
            FoodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            return Price + FoodOrders.Sum(x => x.Price) + DrinkOrders.Sum(x => x.Price);
        }

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            IsReserved = false;
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            return ($"Table: {TableNumber}" + Environment.NewLine +
                   $"Type: {this.GetType().Name}" + Environment.NewLine +
                   $"Capacity: {Capacity}" + Environment.NewLine +
                   $"Price per Person: {PricePerPerson}").ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {NumberOfPeople}");
            sb.AppendLine(FoodOrders.Any() ? $"Food orders: {FoodOrders.Count}" : "Food orders: None");
            if (FoodOrders.Any())
            {
                foreach (var foodOrder in FoodOrders)
                {
                    sb.AppendLine(foodOrder.ToString());
                }
            }
            sb.AppendLine(DrinkOrders.Any() ? $"Drink orders: {FoodOrders.Count}" : "Drink orders: None");
            if (DrinkOrders.Any())
            {
                foreach (var drinkOrder in DrinkOrders)
                {
                    sb.AppendLine(drinkOrder.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
