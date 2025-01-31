public class Entry
{
    public string _dateTime = "";
    public string _promptAnswered = "";
    public string _userInput = "";

    public void Display()
    {
        Console.WriteLine($@"
[{_dateTime}]
Prompt: {_promptAnswered}
Response: {_userInput}"
        );
    }
}