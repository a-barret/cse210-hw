public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private string _reflectionPrepMessage;
    private List<string> _questions = new List<string>();
    private int _reflectionDuration;

    public ReflectionActivity()
    {
        _prompts.AddRange(new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        });
        _reflectionPrepMessage = @"Now ponder each of the following questions as they relate to this experience.
You may begin in: ";
        _questions.AddRange(new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        });
        _reflectionDuration = 8;

        base._type = "Reflection Activity";
        base._introduction = @"Welcome to the Reflecting Activity!

This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.

";
    }

    public string GetPrompt()
    {
        Random random = new Random();
        int number = random.Next(0,_prompts.Count);
        return $@"
Consider the following prompt:

 --- {_prompts[number]} ---
 
When you have something in mind, press ENTER to continue.";
    }
    public string GetReflectionPrepMessage()
    {
        return _reflectionPrepMessage;
    }
    public string GetQuestion()
    {
        Random random = new Random();
        int number = random.Next(0,_questions.Count);
        return _questions[number];
    }
    public int GetReflectionDuration()
    {
        return _reflectionDuration;
    }
}