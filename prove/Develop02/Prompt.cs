public class Prompt
{
    public List<string> _prompts {get; set;} = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is the hardest thing that you did today?",
        "What did you eat today?",
        "What is one thing that you are grateful for?",
        "What is your greatest regret?",
        "Where do you see yourself in 5 years?"
    };
    public string _greeting = "\nWelcome to the Journaling Program!";

    public string GetPrompt()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, _prompts.Count);
        Console.Write($"Prompt: {_prompts[randomNumber]}\nResponse: ");
        return _prompts[randomNumber];
    }
}