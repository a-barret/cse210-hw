using System.IO;

public class Journal
{
    public string _title = "";
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(string promptAnswered, string userInput)
    {
        Entry myEntry = new Entry();
        myEntry._dateTime = DateTime.Now.ToString("M/d/yy h:mm tt");
        myEntry._promptAnswered = promptAnswered;
        myEntry._userInput = userInput;
        _entries.Add(myEntry);
        Console.WriteLine();
        Console.WriteLine("Entry added to your journal.");
    }

    public void Display()
    {
        Console.WriteLine($@"
Title: {_title}"
        );
        foreach (Entry e in _entries)
        {
            e.Display();
        }
        Console.WriteLine();
        Console.WriteLine("[End of journal entries]");
    }

    // Method to save the journal to the file.
    public void SaveFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_title);
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine($"{e._dateTime}|{e._promptAnswered}|{e._userInput}");
            }
        }
        Console.WriteLine();
        Console.WriteLine($"Journal saved to {fileName}.");
    }

    public Journal LoadFile(string fileName)
    {
        Journal journal = new Journal();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        bool isFirstLine = true;

        foreach (string line in lines)
        {
            if (isFirstLine == true) {
                journal._title = line;
                isFirstLine = false;
                continue;
            }

            Entry entry = new Entry();
            string[] parts = line.Split("|");
            entry._dateTime = parts[0];
            entry._promptAnswered = parts[1];
            entry._userInput = parts[2];
            journal._entries.Add(entry);
        }
        Console.WriteLine();
        Console.WriteLine($"Journal loaded from {fileName}.");
        return journal;
    }
}