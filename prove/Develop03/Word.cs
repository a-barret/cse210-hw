public class Word
{
    private bool _isBlank;
    private string _word;
    private string _blank;
    
    public Word()
    {
        _isBlank = false;
        _word = " ";
        _blank = new string('_', _word.Length);
    }
    public Word(string word)
    {
        _isBlank = false;
        _word = word;
        _blank = new string('_', _word.Length);
    }

    public string GetWord()
    {
        return _word;
    }
    public void SetWord(string word)
    {
        _word = word;
    }
    public string GetBlank()
    {
        return _blank;
    }
    public bool GetIsBlank()
    {
        return _isBlank;
    }
    public void SetIsBlank(bool state)
    {
        _isBlank = state;
    }
}