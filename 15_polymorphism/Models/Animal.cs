using System;
using Seido.Utilities.SeedGenerator;
namespace _15_polymorphism.Models;

public enum NordicAnimalKind { Moose, Wolf, Deer, Bear, Fox}
public enum AfricanAnimalKind { Aligator, Elephant, Lion, Donkey, Monkey}
public enum HunterBirdKind {Eagle, Hawk, Owl, Falcon}

public enum AnimalMood { Happy, Sleepy, Sad, Hungry, Lazy, Quick, Slow }
public class Animal: ISeed<Animal>
{
	public AnimalMood Mood { get; set; }
	public int Age { get; set; }
	public string Name { get; set; }

	public virtual string MakeSound()
    {
        return "Generic animal sound";
    }
	public override string ToString() => $"{Name} the {Mood} {Age}yr";
	
	public bool Seeded {get; set;} = false;
	public virtual Animal Seed(SeedGenerator _seeder)
	{
		Mood = _seeder.FromEnum<AnimalMood>();
		Age = _seeder.Next(0, 10);
		Name = _seeder.PetName;
		Seeded = true;
		return this;
	}
	public Animal() { }
	public Animal(Animal org)
	{
		Mood = org.Mood;
		Age = org.Age;
		Name = org.Name;
	}
}

public class NordicAnimal: Animal, ISeed<NordicAnimal>
{
	public NordicAnimalKind Kind {get; set;}
	public bool CanSwim {get; set;}
    public override string ToString()
    {
		return $"{base.ToString()} Kind: {Kind} CanSwim: {CanSwim}";
    }
    public override string MakeSound()
    {
        if(Kind == NordicAnimalKind.Moose) return $"{Kind} Bellow!";
		else if(Kind == NordicAnimalKind.Bear) return $"{Kind} Roar!";
		else if(Kind == NordicAnimalKind.Wolf) return $"{Kind} Howl!";
		else return $"{Kind} makes animal sound";
    }
    public override NordicAnimal Seed(SeedGenerator _seeder)
	{
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<NordicAnimalKind>();
		CanSwim = _seeder.Bool;
		return this;
	}
	public NordicAnimal() {  }
	public NordicAnimal(NordicAnimal copy) : base(copy)
    {
        Kind = copy.Kind;
		CanSwim = copy.CanSwim;
    }
}

public class AfricanAnimal : Animal, ISeed<AfricanAnimal>
{
    public AfricanAnimalKind Kind {get; set;}
	public decimal WeightKg {get; set;}

    public override string MakeSound()
    {
        if(Kind == AfricanAnimalKind.Lion) return $"The {Kind} Roar!";
        else if(Kind == AfricanAnimalKind.Elephant) return $"The {Kind} Trumpet!";
        else if(Kind == AfricanAnimalKind.Monkey) return $"The {Kind} Screech!";
		return $"{Kind} make animal sound..";
    }
    public override string ToString()
    {
        return $"{base.ToString()} Kind {Kind} Weight {WeightKg}kg";
    }
	public override AfricanAnimal Seed(SeedGenerator _seeder)
    {
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<AfricanAnimalKind>();
		WeightKg = _seeder.NextDecimal(50, 5000);
        return this;
    }

	public AfricanAnimal() {}
	public AfricanAnimal(AfricanAnimal copy): base(copy)
    {
        Kind = copy.Kind;
		WeightKg = copy.WeightKg;
    }
}

public class HunterBird : Animal, ISeed<HunterBird>
{
    public HunterBirdKind Kind {get; set;}
	public int WingspanCm {get; set;}
	public bool CanHuntAtNight {get; set;}
    public override string MakeSound()
    {
        return $"{Kind} makes a Screech!";
    }
    public override string ToString()
    {
        return $"{base.ToString()} Kind: {Kind} Wingspan {WingspanCm}cm";
    }
	public override HunterBird Seed(SeedGenerator _seeder)
    {
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<HunterBirdKind>();
		WingspanCm = _seeder.Next(50, 250);
		CanHuntAtNight = _seeder.Bool;
        return this;
    }

	public HunterBird() {}
	public HunterBird(HunterBird copy): base(copy)
    {
        Kind = copy.Kind;
		WingspanCm = copy.WingspanCm;
		CanHuntAtNight = copy.CanHuntAtNight;
    }

	public HunterBird Hunt()
    {
        Mood = AnimalMood.Quick;
		System.Console.WriteLine($"{Name} is hunting and is {Mood}");
		return this;
    }
	public HunterBird Fly()
    {
        Mood = AnimalMood.Happy;
		System.Console.WriteLine($"{Name} is flying and {Mood}");
		return this;
    }
	public HunterBird Rest()
    {
        Mood = AnimalMood.Sleepy;
		System.Console.WriteLine($"{Name} is resting and is {Mood}");
		return this;
    }
}

