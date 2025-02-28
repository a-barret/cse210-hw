using System;

class Program
{
    static void Main(string[] args)
    {
        string menuSelection;

        static void Menu()
        {
            Console.Clear();
            Console.Write(@"Menu Options:
  1. Start Breathing Activity
  2. Start Reflecting Activity
  3. Start Listing Activity
  4. Quit
Select a choice from the menu: ");
        }

        do {
            Menu();
            menuSelection = Console.ReadLine();

            switch (menuSelection) {
                case "1":
                    Console.WriteLine("You have selected the breathing activity.");
                    break;
                case "2":
                    Console.WriteLine("You have selected the reflecting activity.");
                    break;
                case "3":
                    Console.WriteLine("You have selected the listing activity.");
                    break;
                case "4":
                    Console.WriteLine("You have selected quit.");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (menuSelection != "4");
    }
}