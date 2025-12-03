// See https://aka.ms/new-console-template for more information
using Seido.Utilities.SeedGenerator;
using _15_polymorphism.Models;
using System.Runtime.InteropServices;

Console.WriteLine("Hello Polymorphism!");

var seeder = new SeedGenerator();
var animal = new Animal().Seed(seeder);
System.Console.WriteLine(animal);

var animals = seeder.ItemsToList<Animal>(5);
foreach (var a in animals)
{
    System.Console.WriteLine(a);
}

var nordicAnimal = new NordicAnimal().Seed(seeder);

System.Console.WriteLine(nordicAnimal.MakeSound());

var Zoo = new Zoo();
var nordicAnimals = seeder.ItemsToList<NordicAnimal>(5);
var africanAnimals = seeder.ItemsToList<AfricanAnimal>(5);
var hunterBirds = seeder.ItemsToList<HunterBird>(5);

foreach(var n in nordicAnimals)
{
    Zoo.ListOfAnimal.Add(n);
}
foreach(var a in africanAnimals)
{
    Zoo.ListOfAnimal.Add(a);
}
foreach(var h in hunterBirds)
{
    Zoo.ListOfAnimal.Add(h);
}

Console.WriteLine(Zoo.ToString());

// foreach (var item in Zoo.ListOfAnimal)
// {
//     System.Console.WriteLine(item.MakeSound());
// }

void ReseedAllAnimals(List<Animal> animals, SeedGenerator seeder)
{
    foreach(var a in animals)
    {
        a.Seed(seeder);
    }
}

ReseedAllAnimals(Zoo.ListOfAnimal, seeder);

System.Console.WriteLine(Zoo.ToString());
/*
var nordicAnimal = new NordicAnimal().Seed(seeder);
System.Console.WriteLine(nordicAnimal);

var africanAnimal = new AfricanAnimal().Seed(seeder);
System.Console.WriteLine(africanAnimal);

var hunterBird = new HunterBird().Seed(seeder);
System.Console.WriteLine(hunterBird);

hunterBird.Hunt().Fly().Rest();
*/