using System;

class Program
{
    static void Main(string[] args)
    {
        Prompt prompt = new Prompt();
        Console.WriteLine();
        Console.WriteLine(prompt._greeting);

        Journal myJournal = new Journal();

        int menuChoice;

        do
        {
            Console.Write(@"
Please select a menu option:
1. Write new entry
2. View entries
3. Save to file
4. Load from file
5. Quit

Menu Choice: "
            );
            menuChoice = int.Parse(Console.ReadLine());

            if (menuChoice == 1) {

                string randomPrompt = prompt.GetPrompt();
                string userInput = Console.ReadLine();
                myJournal.AddEntry(randomPrompt, userInput);

            } else if (menuChoice == 2) {

                myJournal.Display();

            } else if (menuChoice == 3) {

                Console.WriteLine();
                Console.WriteLine("Enter the file name:");
                string fileName = Console.ReadLine();
                myJournal.SaveFile(fileName);

            } else if (menuChoice == 4) {

                Console.WriteLine();
                Console.WriteLine("Enter the file name:");
                string fileName = Console.ReadLine();
                myJournal = myJournal.LoadFile(fileName);

            }

        } while (menuChoice != 5);
    }
}