class SavingsAccount : Account
{
    public SavingsAccount(string accountName, float interestRate, float startingBalance)
        : base(accountName, interestRate, startingBalance) {}
    public SavingsAccount(int ID, string accountName, float interestRate, float startingBalance)
        : base(ID, accountName, interestRate, startingBalance) {}
}