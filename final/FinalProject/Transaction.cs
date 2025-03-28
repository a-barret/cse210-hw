public class Transaction
{
    private DateTime _date;
    private float _amount;
    private string _category;
    private string _description;

    public Transaction(DateTime date, float amount, string category, string description)
    {
        _date = date;
        _amount = amount;
        _category = category;
        _description = description;
    }

    public string DisplayTransaction()
    {
        return _date.ToString("M/d/yy") + _amount.ToString() + _category + _description;
    }
}