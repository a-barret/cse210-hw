public class Scripture
{
    private string _scriptureText;
    private List<Word> _words = new List<Word>();

    public Scripture()
    {
        _scriptureText = "16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life. 17 For God sent not his Son into the world to condemn the world; but that the world through him might be saved.";
        string[] words = _scriptureText.Split(" ");
        foreach (string w in words)
        {
            Word word = new Word(w);
            _words.Add(word);
        }
    }

    public string GetScripture()
    {
        return _scriptureText;
    }
    public void SetScripture(string scriptureText)
    {
        _scriptureText = scriptureText;
    }
    public List<Word> GetWords()
    {
        return _words;
    }
}