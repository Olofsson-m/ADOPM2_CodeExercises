using Microsoft.AspNetCore.Http.Features;
using Seido.Utilities.SeedGenerator;

namespace _04_wines;

class Program
{
    static void Main(string[] args)
    {
        SeedGenerator rnd = new SeedGenerator();

        WineBottle w1 = new WineBottle(rnd);
        WineCellar wines = new WineCellar("My wine cellar.");

        Console.WriteLine(w1);

        w1.Price = 699.99m;

        Console.WriteLine(w1.ToString());
        for (int i = 0; i < 10; i++)
        {
            wines.wineCellar.Add(new WineBottle(rnd));
        }

        foreach (var item in wines.wineCellar)
        {
            Console.WriteLine(item.ToString());
        }

        var highestPrice = wines.wineCellar.OrderByDescending(p => p.Price).First();
        var cheapestPrice = wines.wineCellar.OrderBy(p => p.Price).First();
        
        Console.WriteLine($"Most expensive: {highestPrice.Price}kr");
        Console.WriteLine($"Cheapest: {cheapestPrice.Price}kr");

        Console.WriteLine($"The winecellar is worth: {wines.Price}kr");
    }
}
//Exercise:
// 1. Modellera en flaska vin en C# class. Utmärkande för ett vin är
//    Druva: Reissling, Tempranillo, Chardonay, Shiraz, Cabernet Savignoin, Syrah
//    Typ: Rött, vitt, rose
//    Namn: namnet på vinet
//    Land: Tyskland, Frankrike, Spanien
//    Pris:
//
// 2. När vinet väl är skapad så ska man bara kunna ändra pris.

// 3. Gör en constructor Wine(csSeedGenerator _seeder) som initierar ett vin
//
// 3. Skapa en ToString i din vinklass som presenterar vinet.
//
// 4. Skapa en vinkällare bestående av 10 flaskor av slumpmässig Druva,
//    Typ, Namn, Land och pris
//
// 5. Vilket är det billigaste och dyraste vinet i vinkällaren?
//
// 7. Vad är värdet av vinkällaren?
//
// 8. Deklarera en contruktor som tillåter dig att själv bestämma alla Wine public properties
//
// 9. Deklarera en Copy constructor.
//
// 10. Använd copy constructorn för att skapa en ny lista av 10 viner med samma
//    innehåll som ursprungslistan
