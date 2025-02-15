public class Reference
{
    private string _book;
    private string _chapter;
    private string _startVerse;
    private string _endVerse;

    public Reference()
    {
        _book = "John";
        _chapter = "3";
        _startVerse = "16";
        _endVerse = "17";
    }

    public string GetReference()
    {
        if (_endVerse.Length > 0) {
            return _book + _chapter + ':' + _startVerse + '-' + _endVerse;
        } else {
            return _book + _chapter + ':' + _startVerse;
        }
    }
}