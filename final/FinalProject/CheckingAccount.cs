class CheckingAccount : Account
{
    private List<string> _cardNames;

    public CheckingAccount(string accountName, float interestRate, float startingBalance, string cardName)
        : base(accountName, interestRate, startingBalance)
    {
        _cardNames = [cardName];
    }
}