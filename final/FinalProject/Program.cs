using System;

class Program
{
    static void Main(string[] args)
    {
        List<Transaction> transactions;

        static string GetMenu()
        {
            return @"
Select an action:
0. Quit
1. Add Transaction
2. Save Accounts
3. Load Accounts
4. View Transactions
5. Generate Report
Enter your selection: ";
        }

        int menuSelection = -1;

        do
        {
            Console.Write(GetMenu());
            try
            {
                menuSelection = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Must be entered as an integer.");
            }
            switch (menuSelection)
            {
                default:
                    Console.WriteLine("Invalid entry");
                    break;
                case 0:
                    // Console.WriteLine("Quit has been selected");
                    break;
                case 1:
                    Console.WriteLine("You have selected Add Transaction");
                    break;
                case 2:
                    Console.WriteLine("You have selected Save Transactions");
                    break;
                case 3:
                    Console.WriteLine("You have selected Load Transactions");
                    break;
                case 4:
                    Console.WriteLine("You have selected View Transactions");
                    break;
                case 5:
                    Console.WriteLine("You have selected Generate Report");
                    break;
            }
        } while (menuSelection != 0);
    }
}