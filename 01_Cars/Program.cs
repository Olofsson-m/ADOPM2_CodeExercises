using Seido.Utilities.SeedGenerator;

namespace _01_Cars;

class Program
{
    public enum CarColor
    {
        Brown, Red, Green, Burgundy
    }
    public enum CarBrand
    {
        Boxcar, Ford, Jaguar, Honda
    }
    public enum CarModel
    {
        Boxmodel, Mustang_GT, XF, Civic
    }
    struct Car
    {
        public CarColor Color { get; init; }
        public CarBrand Brand { get; init; }
        public CarModel Model { get; init; }

        public Car(SeedGenerator _seeder)
        {
            Color = _seeder.FromEnum<CarColor>();
            Brand = _seeder.FromEnum<CarBrand>();
            Model = _seeder.FromEnum<CarModel>();
        }
        public Car(CarColor color, CarBrand brand, CarModel model)
        {
            Color = color;
            Brand = brand;
            Model = model;
        }
        public Car(Car other)
        {
            Color = other.Color;
            Brand = other.Brand;
            Model = other.Model;
        }

        public override string ToString()
        {
            return $"I am a {Color} {Brand} {Model}";
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Class exploration with Cars!");

        #region how To use the seed generator
        var rnd = new SeedGenerator();

        //A random enCarColor
        CarColor rndColor = rnd.FromEnum<CarColor>();
        Console.WriteLine(rndColor.ToString());

        //A random enCarBrand
        Console.WriteLine(rnd.FromEnum<CarBrand>());

        //A random enCarModel
        Console.WriteLine(rnd.FromEnum<CarModel>());
        #endregion
        Car car1 = new Car(rnd);
        Car car2 = new Car(rnd);
        Car car3 = new Car(rnd) {Brand = CarBrand.Ford, Model = CarModel.Civic};
        Car car4 = new Car(CarColor.Red, CarBrand.Ford, CarModel.Mustang_GT);
        Console.WriteLine(car1.ToString());
        Console.WriteLine();
        Console.WriteLine(car2.ToString());
        Console.WriteLine();
        Console.WriteLine(car3.ToString());
        Console.WriteLine();
        Console.WriteLine(car4.ToString());
        Car[] carArray = new Car[10];

        System.Console.WriteLine("Original!");
        for (int i = 0; i < carArray.Length; i++)
        {
            carArray[i] = new Car(rnd) {Color = CarColor.Burgundy};
            Console.WriteLine($"{i + 1}: {carArray[i].ToString()}");
            Console.WriteLine();
        }

        Car[] copyOfCars = new Car[10];

        for (int i = 0; i < copyOfCars.Length; i++)
        {
            copyOfCars[i] = carArray[i];
        }
        System.Console.WriteLine("Copied array!");
        for (int i = 0; i < copyOfCars.Length; i++)
        {
            Console.WriteLine(copyOfCars[i].ToString());
        }
    }

    //Exercises:
    //1. Make class Car public field Color a public property with getters and setters

    //2. Create two new public properties in class Car, Brand, Model
    //   (of types enCarBrand and enCarModel)

    // 3. Gör en construtor Car(csSeedGenerator _seeder) som sätter alla properties till
    //    random

    //4. Make a ToString() override that presents for example
    //   "I am a Red Ford Mustang_GT";

    //5. In Main(), create two variables, car1, car2 and instantiate from Car
    //   - presentera car1 and car2

    //6. Modify the properties Color, Brand and Model so that only Color can change
    //   once an instance of Car has been created

    //7. Modify the properties of Brand and Model so they can also be set during
    //   Object initialization, i.e.  new Car(){ Model = ..., Brand = ...}

    //8. Create an array of 10 cars, all of Color Burgundy, all othet properties random

    //9. Change class Car to struct Car and run the program again.

    // 10. Deklarera en construktor som tillåter dig att själv bestämma alla Car public properties

    // 11. Deklarera en Copy constructor.

    // 12. Använd copy constructorn för att skapa en array av 10 bilar som är en kopia av ursprunget
}

