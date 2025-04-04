class CheckingAccount : Account
{
    private List<string> _cardOwners;

    public CheckingAccount(string accountName, float interestRate, float startingBalance, List<string> cardOwners)
        : base(accountName, interestRate, startingBalance)
    {
        _cardOwners = cardOwners;
    }
}