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
        private int capacity;
        private int numberOfPeople;

        private Table()
        {
            foodOrders = new List<IFood>();
            drinkOrders = new List<IDrink>();
        }

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        : this()
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
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

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get
            {
                return (PricePerPerson * NumberOfPeople)+foodOrders.Sum(x => x.Price) + drinkOrders.Sum(x => x.Price);
            }
        }

        public void Reserve(int numberOfPeoples)
        {
            NumberOfPeople = numberOfPeoples;
            IsReserved = true;
        }

        public void OrderFood(IFood food)
        {
            foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            return Price;
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
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
            sb.AppendLine(foodOrders.Any() ? $"Food orders: {foodOrders.Count}" : "Food orders: None");
            if (foodOrders.Any())
            {
                foreach (var foodOrder in foodOrders)
                {
                    sb.AppendLine(foodOrder.ToString());
                }
            }
            sb.AppendLine(drinkOrders.Any() ? $"Drink orders: {foodOrders.Count}" : "Drink orders: None");
            if (drinkOrders.Any())
            {
                foreach (var drinkOrder in drinkOrders)
                {
                    sb.AppendLine(drinkOrder.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
