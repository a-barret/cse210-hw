class AccountReport : Report
{
    private string _accountName;

    public AccountReport(List<Account> accounts) : base(accounts)
    {
        _accountName = accounts[0].GetName();
    }

    public override string DisplayReport()
    {
        return $@"
   ----------   {_accountName} Report   ----------   
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