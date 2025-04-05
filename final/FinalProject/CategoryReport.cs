class CategoryReport : Report
{
    private string _category;

    public CategoryReport(string category, List<Account> accounts) : base(accounts)
    {
        _category = category;
    }

    public override void GenerateReport(List<Account> accounts)
    {
        List<Transaction> allTransactions = new List<Transaction>();
        foreach (Account a in accounts)
        {
            allTransactions.AddRange(a.GetTransactions());
        }
        allTransactions.Sort((t1, t2) => t1.GetDate().CompareTo(t2.GetDate()));
        
        _transactionCount = 0;
        int expenseCount = 0;
        _transactionList = "";
        foreach (Transaction t in allTransactions)
        {
            if (t.GetCategory() == _category)
            {
                _transactionCount++;
                if (t.GetCategory() == "Income" || t.GetCategory() == "Gift" || t.GetCategory() == "Loan Disbursement" || t.GetCategory() == "Grants & Scholarships")
                {
                    _totalIncome += t.GetAmount();
                }
                else
                {
                    _totalSpent += t.GetAmount();
                    expenseCount++;
                }
                _transactionList += t.DisplayTransaction() + "\n";
            }
        }
        _netIncome = _totalIncome + _totalSpent;
        try
        {
            _avgExpense = _totalSpent / expenseCount;
        }
        catch (DivideByZeroException)
        {
            _avgExpense = 0;
        }
    }
    public override string DisplayReport()
    {
        return $@"
   ----------   {_category} Report   ----------   
Total Income: {_totalIncome.ToString("C")}
Total Expense: {_totalSpent.ToString("C")}
Net Income: {_netIncome.ToString("C")}

Average Expense: {_avgExpense.ToString("C")}
Total Transactions: {_transactionCount}

   Transaction List:
{_transactionList}
   ----------   End of report   ----------   ";
    }
}