namespace _04_wines
{
    public class WineCellar
    {
        public string Name;
        public List<WineBottle> wineCellar = new List<WineBottle>();

        public decimal Price
        {
            get
            {
                decimal sum = 0M;
                foreach (var wine in wineCellar)
                {
                    sum += wine.Price;
                }
                return sum;
            }
        }
        public WineCellar(string name)
        {
            Name = name;
        }

    }
}