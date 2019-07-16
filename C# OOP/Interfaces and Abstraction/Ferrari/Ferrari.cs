namespace Ferrari
{
    public class Ferrari:ICar
    {
        private string driver;
        public const string ModelConst = "488-Spider";

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver
        {
            get => driver;
            set => driver = value;
        }

        public string Gas()
        {
            return "Gas!";
        }

        public string Brake()
        {
            return "Brakes!";
        }

        public string Model => ModelConst;

    }
}
