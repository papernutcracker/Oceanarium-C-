using System;
namespace OceanariumProject
{
    public abstract class MarineCreature
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }

        protected MarineCreature(string name, string species, int age)
        {
            Name = name;
            Species = species;
            Age = age;
        }

        public abstract void DisplayInfo();
    }
    public class Fish : MarineCreature
    {
        public string WaterType { get; set; }

        public Fish(string name, string species, int age, string waterType)
            : base(name, species, age)
        {
            WaterType = waterType;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Fish] Name: {Name}, Species: {Species}, Age: {Age}, Water Type: {WaterType}");
        }
    }
    public class Mammal : MarineCreature
    {
        public bool IsTrained { get; set; }

        public Mammal(string name, string species, int age, bool isTrained)
            : base(name, species, age)
        {
            IsTrained = isTrained;
        }

        public override void DisplayInfo()
        {
            string trainedStatus = IsTrained ? "Trained" : "Wild";
            Console.WriteLine($"[Mammal] Name: {Name}, Species: {Species}, Age: {Age}, Status: {trainedStatus}");
        }
    }
    public class Invertebrate : MarineCreature
    {
        public bool IsVenomous { get; set; }

        public Invertebrate(string name, string species, int age, bool isVenomous)
            : base(name, species, age)
        {
            IsVenomous = isVenomous;
        }

        public override void DisplayInfo()
        {
            string venomStatus = IsVenomous ? "Venomous" : "Harmless";
            Console.WriteLine($"[Invertebrate] Name: {Name}, Species: {Species}, Age: {Age}, Trait: {venomStatus}");
        }
    }
}
