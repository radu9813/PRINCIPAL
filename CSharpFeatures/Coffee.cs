namespace CSharpFeatures
{
    internal class Coffee
    {
      

        public Coffee(string coffeType)
        {
            this.CoffeeType = coffeType;
        }

        public string CoffeeType { get; set; }

        public override string ToString()
        {
            return CoffeeType;
        }
    }
}