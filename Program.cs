using System;
namespace OceanariumProject
{
    class Program
    {
        static void Main()
        {
            Oceanarium myOceanarium = new Oceanarium();
            bool isRunning = true;

            string[] menuOptions = {
                "Add a Fish",
                "Add a Mammal",
                "Add an Invertebrate",
                "Show all inhabitants",
                "Exit"
            };

            while (isRunning)
            {
                int selectedIndex = GetMenuSelection("=== Interactive Oceanarium Manager ===", menuOptions);

                Console.Clear();

                switch (selectedIndex)
                {
                    case 0:
                        AddCreatureInteractive(myOceanarium, "Fish");
                        break;
                    case 1:
                        AddCreatureInteractive(myOceanarium, "Mammal");
                        break;
                    case 2:
                        AddCreatureInteractive(myOceanarium, "Invertebrate");
                        break;
                    case 3:
                        myOceanarium.ShowAllInhabitants();
                        break;
                    case 4:
                        isRunning = false;
                        Console.WriteLine("Exiting the Oceanarium Manager. Goodbye!");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey(true);
                }
            }
        }
        static void AddCreatureInteractive(Oceanarium oceanarium, string typeChoice)
        {
            Console.WriteLine($"--- Adding a new {typeChoice} ---\n");

            string name = GetValidStringInput("Enter name: ");
            string species = GetValidStringInput("Enter species: ");
            int age = GetValidIntInput("Enter age: ");

            switch (typeChoice)
            {
                case "Fish":
                    string[] waterOptions = { "Freshwater", "Saltwater", "Brackish" };
                    string fishContext = $"--- Adding a new Fish ---\nName: {name}\nSpecies: {species}\nAge: {age}\n\nSelect water type:";

                    int waterIndex = GetMenuSelection(fishContext, waterOptions);
                    string waterType = waterOptions[waterIndex];

                    Console.Clear();
                    Console.WriteLine(fishContext);
                    Console.WriteLine($" > {waterType}");

                    oceanarium.AddCreature(new Fish(name, species, age, waterType));
                    break;

                case "Mammal":
                    bool isTrained = GetValidKeyBoolInput("Is this mammal trained? (Y/N): ");
                    oceanarium.AddCreature(new Mammal(name, species, age, isTrained));
                    break;

                case "Invertebrate":
                    bool isVenomous = GetValidKeyBoolInput("Is this invertebrate venomous? (Y/N): ");
                    oceanarium.AddCreature(new Invertebrate(name, species, age, isVenomous));
                    break;
            }
        }
        static int GetMenuSelection(string header, string[] options)
        {
            int selectedIndex = 0;
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                Console.WriteLine("Use Up/Down arrows to navigate and Enter to select.\n");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($" > {options[i]} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {options[i]} ");
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0) selectedIndex = options.Length - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= options.Length) selectedIndex = 0;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = true;
                    return selectedIndex;
                }
            }
        }
        static string GetValidStringInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("ERROR: Input cannot be empty. Please try again.\n");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        static int GetValidIntInput(string prompt)
        {
            int result;
            Console.Write(prompt);

            while (!int.TryParse(Console.ReadLine(), out result) || result < 0)
            {
                Console.WriteLine("ERROR: Invalid input. Please enter a valid positive number.\n");
                Console.Write(prompt);
            }

            return result;
        }

        static bool GetValidKeyBoolInput(string prompt)
        {
            Console.Write(prompt);
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("Yes");
                    return true;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("No");
                    return false;
                }
            }
        }
    }
}
