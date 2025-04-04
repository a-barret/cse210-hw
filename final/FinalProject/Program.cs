using System.IO;

class Program
{
    static void Main(string[] args)
    {
        static string GetMenu()
        {
            return @"
Select an action:
  0. Quit
  1. Add Transaction
  2. Add Account
  3. Save Accounts
  4. Load Accounts
  5. View Accounts
  6. View Transactions
  7. Generate Report
Enter your selection: ";
        }

        static string GetAddMenu(string accountString)
        {
            return "Select an account for the transaction:\n" + accountString + "Enter your account selection: ";
        }

        static string GetCategoryMenu(string categoryString)
        {
            return "Select a category for the transaction:\n" + categoryString + "Enter your category selection: ";
        }

        static string GetAccountTypeMenu()
        {
            return @"Select an account type:
  0. Return
  1. Checking
  2. Savings
Enter your selection: ";
        }

        static string GetAccountList(List<Account> accounts)
        {
            string accountString = "";
            foreach (Account a in accounts)
            {
                accountString += a.DisplayAccount() + "\n";
            }
            return accountString;
        }

        static string GetCategoryList(Dictionary<int, string> categories)
        {
            string categoriesString = "";
            for (int i = 1; i <= categories.Count; i++)
            {
                categoriesString += $"  {i}. {categories[i]}\n";
            }
            return categoriesString;
        }

        static List<object> CreateAccountDialog()
        {
            bool notValid = true;
            List<object> accountParts = new List<object>();
            do
            {
                accountParts = new List<object>();
                Console.Write("Enter the account name: ");
                string accountName = Console.ReadLine();
                accountParts.Add(accountName);
                try
                {
                    Console.Write("Enter the current account balance: ");
                    float startingBalance = float.Parse(Console.ReadLine());
                    accountParts.Add(startingBalance);
                    Console.Write("Enter the account interest rate: ");
                    float interestRate = float.Parse(Console.ReadLine());
                    accountParts.Add(interestRate);
                    notValid = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Must be an integer or decimal.");
                }
            } while (notValid);
            return accountParts;
        }

        static void LoadAccountsFromCSV(string fileName, List<Account> accounts)
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                int ID = int.Parse(parts[0]);
                string type = parts[1];
                string name = parts[2];
                float interestRate = float.Parse(parts[3]);
                float balance = float.Parse(parts[4]);

                if (type == "CheckingAccount")
                {
                    List<string> owners = new List<string>(parts[5].Split(';'));
                    accounts.Add(new CheckingAccount(ID, name, interestRate, balance, owners));
                }
                else if (type == "SavingsAccount")
                {
                    accounts.Add(new SavingsAccount(ID, name, interestRate, balance));
                }
                else
                {
                    Console.WriteLine($"Unknown account type '{type}' on line: {line}");
                }
            }
        }

        static void LoadTransactionsFromCSV(string fileName, List<Account> accounts)
        {
            foreach (Account a in accounts)
            {
                a.ClearTransactions();
            }
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                int accountID = int.Parse(parts[0]);
                DateTime date = DateTime.Parse(parts[1]);
                float amount = float.Parse(parts[2]);
                string category = parts[3];
                string description = parts[4];

                Transaction t = new Transaction(accountID, date, amount, category, description);

                Account target = accounts.Find(a => a.GetID() == accountID);


                if (target != null)
                {
                    target.ImportTransaction(t);
                }
                else
                {
                    Console.WriteLine($"Warning: No account found for transaction on line: {line}");
                }
            }
        }

        static void SaveAccountsToCSV(string fileName, List<Account> accounts)
        {
            List<string> lines = new List<string>();
            foreach (Account a in accounts)
            {
                lines.Add(a.ToCSV());
            }
            File.WriteAllLines(fileName, lines);
        }

        static void SaveTransactionsToCSV(string fileName, List<Account> accounts)
        {
            List<string> lines = new List<string>();
            foreach (Account a in accounts)
            {
                foreach (Transaction t in a.GetTransactions())
                {
                    lines.Add(t.ToCSV());
                }
            }
            File.WriteAllLines(fileName, lines);
        }

        // |======================================================================================|
        // | MAIN PROGRAM START                                                                   |
        // |======================================================================================|

        List<Account> accounts = new List<Account>();
        Dictionary<int, string> categories = new Dictionary<int, string>{
            {1,"Income"},{2,"Gifts"}, {3,"Loan Disbursement"}, {4,"Grants & Scholarships"},
            {5,"Rent"}, {6,"Utilities"}, {7,"Electric"}, {8,"Laundry"}, {9,"Groceries"},
            {10,"School"}, {11,"Home"}, {12,"Eating Out"}, {13,"Loans"}, {14,"Tithing"},
            {15,"Music"}, {16,"Misc E"}, {17,"Cloud Storage"}, {18,"Phone Bill"}, {19,"Misc BS"},
            {20,"Taxes"}, {21,"Gas"}, {22,"Oil Changes & Maint"}, {23,"Misc C"},
            {24,"Travel Fares"}, {25,"Car Insurance"}, {26,"Health Insurance"},
            {27,"Personal Liability Insurance"}, {28,"Doctors Visits"}, {29,"Misc"}
        };
        int menuSelection = -1;

        do
        {
            Console.Clear();
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
                    Console.WriteLine("Invalid menu selection");
                    break;
                case 0:
                    // Console.WriteLine("Quit has been selected");
                    break;
                case 1:
                    int accountSelection = -1;
                    bool accountSelectInvalid = true;

                    Console.Write(GetAddMenu(GetAccountList(accounts)));
                    do
                    {
                        try
                        {
                            accountSelection = int.Parse(Console.ReadLine());
                            accountSelectInvalid = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Must be entered as an integer.");
                        }
                    } while (accountSelectInvalid);

                    if (0 <= accountSelection && accountSelection < accounts.Count)
                    {
                        bool notValid = true;
                        float amountEntry = 0;
                        string categorySelection = "";
                        int categoryKeySelection = 0;
                        do
                        {
                            try
                            {
                                Console.Write("Enter the amount: ");
                                amountEntry = float.Parse(Console.ReadLine());
                                Console.Write(GetCategoryMenu(GetCategoryList(categories)));
                                categoryKeySelection = int.Parse(Console.ReadLine());
                                categorySelection = categories[categoryKeySelection];
                                notValid = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Amount must be a decimal value and category selection must be an integer.");
                            }
                            catch (KeyNotFoundException)
                            {
                                Console.WriteLine("Invalid category number");
                            }
                        } while (notValid);

                        if ((categoryKeySelection <= 4 && amountEntry < 0) || (categoryKeySelection > 4 && amountEntry > 0))
                        {
                            amountEntry *= -1;
                        }

                        Console.Write("Describe the transaction:\n> ");
                        string descriptionEntry = Console.ReadLine();

                        Transaction transaction = new Transaction(accountSelection, DateTime.Now, amountEntry, categorySelection, descriptionEntry);
                        accounts[accountSelection].AddNewTransaction(transaction);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Account ID.");
                    }
                    break;

                case 2:
                    Console.WriteLine("You have selected Add Account");
                    Console.Write(GetAccountTypeMenu());
                    int typeSelection = -1;
                    bool notValidType = true;
                    do
                    {
                        try
                        {
                            typeSelection = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Must be entered as an integer.");
                        }
                        List<object> accountParts = new List<object>();
                        if (typeSelection >= 1 && typeSelection <= 2)
                        {
                            accountParts = CreateAccountDialog();
                        }
                        switch (typeSelection)
                        {
                            default:
                                Console.WriteLine("Invalid menu selection");
                                break;
                            case 0:
                                notValidType = false;
                                break;

                            case 1:
                                
                                bool notValid = true;
                                int cardOwnerCount = 0;
                                do
                                {
                                    cardOwnerCount = 0;
                                    try
                                    {
                                        Console.Write("Enter the number of card owners: ");
                                        cardOwnerCount = int.Parse(Console.ReadLine());
                                        notValid = false;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Must be entered as an integer.");
                                    }
                                } while (notValid);

                                List<string> cardOwners = new List<string>();
                                while (cardOwnerCount > 0)
                                {
                                    Console.Write("Enter a card owner name: ");
                                    string cardOwner = Console.ReadLine();
                                    cardOwners.Add(cardOwner);

                                    cardOwnerCount--;
                                }

                                CheckingAccount checkingAccount = new CheckingAccount((string)accountParts[0],
                                                                                    (float)accountParts[2],
                                                                                    (float)accountParts[1],
                                                                                    cardOwners);
                                accounts.Add(checkingAccount);
                                notValidType = false;
                                break;

                            case 2:
                                SavingsAccount savingsAccount = new((string)accountParts[0],
                                                                    (float)accountParts[2],
                                                                    (float)accountParts[1]);
                                accounts.Add(savingsAccount);
                                notValidType = false;
                                break;
                        }
                    } while (notValidType);
                    break;
                    
                case 3:
                    Console.WriteLine("You have selected Save Accounts");
                    SaveAccountsToCSV("accounts.csv", accounts);
                    SaveTransactionsToCSV("transactions.csv", accounts);
                    break;
                case 4:
                    Console.WriteLine("You have selected Load Accounts");
                    
                    try
                    {
                        LoadAccountsFromCSV("accounts.csv", accounts);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("\"accounts.csv\" could not be found.");
                    }

                    try
                    {
                        LoadTransactionsFromCSV("transactions.csv", accounts);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("\"transactions.csv\" could not be found.");
                    }

                    break;

                case 5:
                    Console.WriteLine("Account List:");
                    Console.WriteLine(GetAccountList(accounts));
                    Console.WriteLine("    ---------- End of Account List ----------   ");
                    break;

                case 6:
                    Console.WriteLine("Transaction List:");
                    List<Transaction> allTransactions = new List<Transaction>();
                    foreach (Account a in accounts)
                    {
                        allTransactions.AddRange(a.GetTransactions());
                    }
                    allTransactions.Sort((t1, t2) => t1.GetDate().CompareTo(t2.GetDate()));
                    foreach (Transaction t in allTransactions)
                    {
                        Console.WriteLine(t.DisplayTransaction());
                    }
                    Console.WriteLine("    ---------- End of Transaction List ----------   ");
                    break;

                case 7:
                    Console.WriteLine("You have selected Generate Report");
                    break;
            }
        } while (menuSelection != 0);
    }
}