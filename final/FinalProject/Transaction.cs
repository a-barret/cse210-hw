// I decided to have just one transaction class with no sub, income or expense
// transaction classes because the same effect can be achieved by allowing
// negative or positive values in the "_amount" attribute of the transaction class.

public class Transaction
{
    //=============================================================================================
    // ATTRIBUTES
    //=============================================================================================
    private int _parentAccountID;
    private DateTime _date;
    private float _amount;
    private string _category;
    private string _description;

    //=============================================================================================
    // CONSTRUCTORS
    //=============================================================================================

    public Transaction(int accountID, DateTime date, float amount, string category, string description)
    {
        _parentAccountID = accountID;
        _date = date;
        _amount = amount;
        _category = category;
        _description = description;
    }

    //=============================================================================================
    // BEHAVIORS
    //=============================================================================================

    public string DisplayTransaction()
    {
        return _date.ToString("M/d/yy") + _amount.ToString() + _category + _description;
    }
    public string ToCSV()
    {
        return $"{_parentAccountID},{_date.ToString("o")},{_amount},{_category},{_description}";
    }
    public DateTime GetDate()
    {
        return _date;
    }
    public float GetAmount()
    {
        return _amount;
    }
}