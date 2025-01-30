public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry()
    {
        Entry newEntry = new Entry();
        _entries.Add(newEntry);
    }

    public void Display()
    {
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    public void SaveFile()
    {

    }

    public void LoadFile()
    {

    }
}