namespace Restaurant
{
    public class Product
    {
        private string name;
        private decimal price;
        public Product(string name,decimal price)
        {
            this.name = name;
            this.price = price;
        }

       

        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set { price = value; }
        }

        
    }
}
