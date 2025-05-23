using System;

class Program
{
    static void Main(string[] args)
    {
        // Returns the string for the menu to display. Takes a user score for telling the user how
        // many points that they have.
        static string DisplayMenu(int score)
        {
            return $@"
You have {score} points.

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

        static List<object> CreateDialog(int goalType)
        {
            List<object> goalParts = new List<object>();
            Console.Write("What is the name of your goal? ");
            goalParts.Add(Console.ReadLine());
            Console.Write("What is a short description of it? ");
            goalParts.Add(Console.ReadLine());
            bool notValid = true;
            while (notValid)
            {
                try
                {
                    Console.Write("What is the amount of points associated with this goal? ");
                    goalParts.Add(int.Parse(Console.ReadLine()));
                    notValid = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Must be entered as an integer.");
                }
            }
            if (goalType == 3)
            {
                notValid = true;
                while (notValid)
                {
                    try
                    {
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        goalParts.Add(int.Parse(Console.ReadLine()));
                        notValid = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Must be entered as an integer.");
                    }
                }
                Console.Write("What is the bonus for accomplishing it that many times? ");
                goalParts.Add(int.Parse(Console.ReadLine()));
            }
            return goalParts;
        }


//=================================================================================================
// This begins the main program 
//=================================================================================================


        List<Goal> goals = new List<Goal>();
        int score = 0;
        int menuSelection;
        string fileName;
        
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
                                List<object> simpleGoalParts = CreateDialog(menuSelection);
                                Simple simple = new Simple((string)simpleGoalParts[0],
                                                           (string)simpleGoalParts[1],
                                                           (int)simpleGoalParts[2]);
                                goals.Add(simple);
                                break;
                            case 2:
                                List<object> eternalGoalParts = CreateDialog(menuSelection);
                                Eternal eternal = new Eternal((string)eternalGoalParts[0],
                                                              (string)eternalGoalParts[1],
                                                              (int)eternalGoalParts[2]);
                                goals.Add(eternal);                        
                                break;
                            case 3:
                                List<object> checklistGoalParts = CreateDialog(menuSelection);
                                Checklist checklist = new Checklist((string)checklistGoalParts[0],
                                                                    (string)checklistGoalParts[1],
                                                                    (int)checklistGoalParts[2],
                                                                    (int)checklistGoalParts[3],
                                                                    (int)checklistGoalParts[4]);
                                goals.Add(checklist);
                                break;
                            default:
                                Console.WriteLine("Invalid entry");
                                break;
                        }
                    } while (menuSelection < 1 || menuSelection > 3);
                    break;
                case 2:
                    Console.WriteLine("The goals are:");
                    foreach (Goal goal in goals)
                    {
                        Console.WriteLine($"{goal.DisplayGoal()}");
                    }
                    break;
                case 3:
                    Console.Write("Enter the file name: ");
                    fileName = Console.ReadLine();
                    using (StreamWriter outputFile = new StreamWriter(fileName))
                    {
                        outputFile.WriteLine(score);
                        foreach (Goal goal in goals)
                        {
                            outputFile.WriteLine(goal.SaveGoal());
                        }
                    }
                    break;
                case 4:
                    Console.Write("Enter the file name: ");
                    fileName = Console.ReadLine();
                    string[] lines = System.IO.File.ReadAllLines(fileName);
                    bool isFirstLine = true;

                    foreach (string line in lines)
                    {
                        if (isFirstLine) {
                            score = int.Parse(line);
                            isFirstLine = false;
                        } else {
                            string[] parts = line.Split("|");
                            if (parts[5] == "simple") {
                                Simple goal = new Simple(parts[0],
                                                         parts[1],
                                                         int.Parse(parts[2]),
                                                         int.Parse(parts[3]),
                                                         parts[4]);
                                goals.Add(goal);
                            } else if (parts[5] == "eternal") {
                                Eternal goal = new Eternal(parts[0],
                                                           parts[1],
                                                           int.Parse(parts[2]),
                                                           int.Parse(parts[3]),
                                                           parts[4]);
                                goals.Add(goal);
                            } else if (parts[5] == "checklist") {
                                Checklist goal = new Checklist(parts[0],
                                                               parts[1],
                                                               int.Parse(parts[2]),
                                                               int.Parse(parts[3]),
                                                               parts[4],
                                                               int.Parse(parts[6]),
                                                               int.Parse(parts[7]),
                                                               int.Parse(parts[8]));
                                goals.Add(goal);
                            }
                        }
                    }
                    break;
                case 5:
                    Console.WriteLine("The goals are:");
                    foreach (Goal goal in goals)
                    {
                        Console.WriteLine($"  {goal.GetName()}");
                    }
                    Console.Write("Which goal did you accomplish? ");
                    int goalCompleted = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine($"Congratulations! You have earned {goals[goalCompleted].GetPoints()} points!");
                    goals[goalCompleted].MarkComplete();
                    score += goals[goalCompleted].GetPoints();
                    Console.WriteLine($"You now have {score} points.");
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