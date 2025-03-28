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
2. Save Transactions
3. Load Transactions
4. Generate Report
5. View Transactions
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
            catch
            {
                
            }
            switch (menuSelection)
            {
                case 1:

            }
        } while (menuSelection != 0);
    }
}