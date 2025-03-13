using System;

class Program
{
    static void Main(string[] args)
    {
        static string DisplayMenu(int score)
        {
            return $@"You have {score} points.

Menu Options:
1. Create New Goal
2. List Goals
3. Save Goals
4. Load Goals
5. Record Event
6. Quit
Select a choice from the menu: ";
        }

        static string DisplayCreateMenu()
        {
            return @"The types of Goals are:
  1. Simple Goal
  2. Eternal Goal
  3. Checklist Goal
Which type of goal would you like to create? ";
        }

        int score = 0;
        int menuSelection;

        do
        {
            Console.Write(DisplayMenu(score));
            try
            {
                menuSelection = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                menuSelection = 0;
            }

            switch (menuSelection)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("Create new goal selected");
                        Console.Write(DisplayCreateMenu());
                        try
                        {
                            menuSelection = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            menuSelection = 0;
                        }

                        switch (menuSelection)
                        {
                            case 1:
                                Console.WriteLine("Simple selected");
                                break;
                            case 2:
                                Console.WriteLine("Eternal selected");
                                break;
                            case 3:
                                Console.WriteLine("Checklist selected");
                                break;
                            default:
                                Console.WriteLine("Invalid entry");
                                break;
                        }
                    } while (menuSelection < 1 || menuSelection > 3);
                    break;
                case 2:
                    Console.WriteLine("List goals selected");
                    break;
                case 3:
                    Console.WriteLine("Save goals selected");
                    break;
                case 4:
                    Console.WriteLine("Load goals selected");
                    break;
                case 5:
                    Console.WriteLine("Record event selected");
                    break;
                case 6:
                    Console.WriteLine("Quit selected");
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    break;
            }
        } while (menuSelection != 6);
    }
}