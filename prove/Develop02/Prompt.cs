public class Prompt
{
    public List<Prompt> _prompts = new List<Prompt>();
    public string _greeting = "";

    public void GetPrompt()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, _prompts.Count);
        Console.WriteLine($"{_prompts[randomNumber]}");
    }
}