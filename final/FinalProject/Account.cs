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

    public Account(int ID, string accountName, float interestRate, float startingBalance)
    {
        _ID = ID;
        if (_nextAvailableID <= ID)
        {
            _nextAvailableID++;
        }
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
    public virtual string ToCSV()
    {
        return $"{_ID},{GetType().Name},{_accountName},{_interestRate},{_balance}";
    }
    public List<Transaction> GetTransactions()
    {
        return _transactions;
    }
    public void AddNewTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        _balance += transaction.GetAmount();
    }
    public void LoadTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }
    public void ClearTransactions()
    {
        _transactions = new List<Transaction>();
    }
    public int GetID()
    {
        return _ID;
    }
    public string GetName()
    {
        return _accountName;
    }
}