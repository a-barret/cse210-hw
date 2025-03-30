public class Account
{
    private string _accountName;
    private float _interestRate;
    private float _balance;
    private List<Transaction> _transactions;

    public Account(string accountName, float interestRate, float startingBalance)
    {
        _accountName = accountName;
        _balance = startingBalance;
        _interestRate = interestRate;
        _transactions = new List<Transaction>();
    }

    public string DisplayAccount()
    {
        return $"{_accountName} - Balance: ${_balance} (Interest Rate: %{_interestRate})";
    }
    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        _balance += transaction.GetAmount();
    }
}