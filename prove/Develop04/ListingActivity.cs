public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>();

    public ListingActivity()
    {
        _prompts.AddRange(new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        });

        base._type = "Listing Activity";
        base._introduction = @"Welcome to the Listing Activity!

This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.

";
    }

    public string GetPrompt()
    {
        Random random = new Random();
        int number = random.Next(0,_prompts.Count);
        return $@"
List as many responses as you can to the following prompt:

 --- {_prompts[number]} ---
 
You may begin in: ";
    }
}