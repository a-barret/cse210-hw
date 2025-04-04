public class Account
{
    //=============================================================================================
    // ATTRIBUTES
    //=============================================================================================

    private int _ID;
    private string _accountName;
    private float _interestRate;
    private float _balance;
    private List<Transaction> _transactions;
    private static int _nextAvailableID = 0;

    //=============================================================================================
    // CONSTRUCTORS
    //=============================================================================================

    public Account(string accountName, float interestRate, float startingBalance)
    {
        _ID = _nextAvailableID;
        _nextAvailableID++;
        _accountName = accountName;
        _balance = startingBalance;
        _interestRate = interestRate;
        _transactions = new List<Transaction>();
    }

    //=============================================================================================
    // BEHAVIORS
    //=============================================================================================

    public string DisplayAccount()
    {
        return $"  {_ID}. {_accountName} - Balance: ${Math.Round(_balance, 2)} (Interest Rate: %{Math.Round(_interestRate, 2)})";
    }
    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        _balance += transaction.GetAmount();
    }

    public int GetID()
    {
        return _ID;
    }
}