class CheckingAccount : Account
{
    private List<string> _cardOwners;

    public CheckingAccount(string accountName, float interestRate, float startingBalance, List<string> cardOwners)
        : base(accountName, interestRate, startingBalance)
    {
        _cardOwners = cardOwners;
    }
    public CheckingAccount(int ID, string accountName, float interestRate, float startingBalance, List<string> cardOwners)
        : base(ID, accountName, interestRate, startingBalance)
    {
        _cardOwners = cardOwners;
    }
    public override string ToCSV()
    {
        string owners = string.Join(";", _cardOwners);
        return base.ToCSV() + $",{owners}";
    }
}