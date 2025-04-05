using System.Linq.Expressions;

class Report
{
    private DateTime _generationDate;
    protected float _totalIncome;
    protected float _totalSpent;
    protected float _netIncome;
    protected float _avgExpense;
    protected int _transactionCount;
    protected string _transactionList;

    public Report() {}
    public Report(List<Account> accounts)
    {
        _generationDate = DateTime.Now;
        GenerateReport(accounts);
    }

    public virtual void GenerateReport(List<Account> accounts)
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

    public virtual string DisplayReport()
    {
        return $@"
   ----------   General Report   ----------   
Date: {_generationDate.ToString("d")}

Total Income: {_totalIncome.ToString("C")}
Total Expense: {_totalSpent.ToString("C")}
Net Income: {_netIncome.ToString("C")}

Average Expense: {_avgExpense.ToString("C")}
Total Transactions: {_transactionCount}

   Transaction List:
{_transactionList}
   ----------   End of report    ----------   ";
    }
}