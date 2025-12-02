using Seido.Utilities.SeedGenerator;

namespace _04_wines
{
    public enum Grapes {Reissling, Tempranillo, Chardonay, Shiraz, Cabernet, Savignoin, Syrah}
    public enum Type {Red, White, Rosé}
    public enum Country {Germany, France, Spain}
    public class WineBottle
    {
        public Grapes Grapes {get; init;}
        public Type Type {get; init;}
        public Country Country {get; init;}
        public string Name {get; init;}
        public decimal Price {get; set;}

        public WineBottle(SeedGenerator _seeder)
        {
            Grapes = _seeder.FromEnum<Grapes>();
            Type = _seeder.FromEnum<Type>();
            Country = _seeder.FromEnum<Country>();
            Name = _seeder.FirstName;
            Price = _seeder.NextDecimal(50, 1000);
        }

        public WineBottle(WineBottle other)
        {
            Grapes = other.Grapes;
            Type = other.Type;
            Country = other.Country;
            Name = other.Name;
            Price = other.Price;
        }

        public override string ToString()
        {
            return $"{Name} is a {Type} wine from {Country} and is made from {Grapes}. The current price is {Price}kr";
        }
    }

}