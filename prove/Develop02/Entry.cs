public class Entry
{
    public string _userInput = "";
    public string _dateTime = "";

    public void Display()
    {

        Console.WriteLine($"[{_dateTime}] {_userInput}");
    }
}