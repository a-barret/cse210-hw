using System;

class Program
{
    static void Main(string[] args)
    {
        string menuSelection;

        Report report = new Report();


        static void Menu()
        {
            Console.Clear();
            Console.Write(@"Menu Options:
  1. Start Breathing Activity
  2. Start Reflecting Activity
  3. Start Listing Activity
  4. View Activity Report
  5. Quit
Select a choice from the menu: ");
        }

        static void AnimateLoading(int duration)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);
            string loadSymbol = "|";
            while (DateTime.Now < endTime)
            {
                Console.Write(loadSymbol);
                Thread.Sleep(125);
                Console.Write("\b \b");

                switch (loadSymbol)
                {
                    case "|":
                        loadSymbol = "/";
                        break;
                    case "/":
                        loadSymbol = "-";
                        break;
                    case "-":
                        loadSymbol = @"\";
                        break;
                    case @"\":
                        loadSymbol = "|";
                        break;
                }
            }
            Console.Write("\b \b");
        }

        static void AnimateCountdown(int duration)
        {
            for (int i = duration; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        static void IntroduceActivity(Activity activity)
        {
            Console.Clear();
            Console.WriteLine(activity.GetIntroduction());
            int duration = int.Parse(Console.ReadLine());
            Console.Clear();

            activity.SetDuration(duration);

            Console.WriteLine(activity.GetPrepMessage());
            AnimateLoading(activity.GetPauseLength());
        }

        static string PlaythroughActivity(Activity activity)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(activity.GetDuration());
            int itemsListed = 0;
            while (DateTime.Now < endTime)
            {
                switch (activity)
                {
                    case BreathingActivity breathingActivity:
                        Console.Write(breathingActivity.GetBreathMessage());
                        AnimateCountdown(breathingActivity.GetBreathDuration());
                        Console.WriteLine();
                        break;
                    case ReflectionActivity reflectionActivity:
                        Console.Write(reflectionActivity.GetQuestion() + " ");
                        AnimateLoading(reflectionActivity.GetReflectionDuration());
                        Console.WriteLine();
                        break;
                    case ListingActivity:
                        Console.Write("> ");
                        Console.ReadLine();
                        itemsListed += 1;
                        break;
                }
            }
            return $"You listed {itemsListed} items!";
        }

        static void FinishActivity(Activity activity)
        {
            Console.WriteLine(activity.GetCompleteMessage());
            AnimateLoading(activity.GetPauseLength());
            Console.WriteLine();
            Console.WriteLine(activity.GetExitMessage());
            AnimateLoading(activity.GetPauseLength());
        }

        do
        {
            Menu();
            menuSelection = Console.ReadLine();

            switch (menuSelection)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();

                    IntroduceActivity(breathingActivity);

                    PlaythroughActivity(breathingActivity);

                    FinishActivity(breathingActivity);

                    report.SetSeconds(breathingActivity);

                    break;


                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();

                    IntroduceActivity(reflectionActivity);

                    Console.WriteLine(reflectionActivity.GetPrompt());
                    Console.ReadLine();

                    Console.Write(reflectionActivity.GetReflectionPrepMessage());
                    AnimateCountdown(reflectionActivity.GetPauseLength());
                    Console.Clear();

                    PlaythroughActivity(reflectionActivity);

                    FinishActivity(reflectionActivity);

                    report.SetSeconds(reflectionActivity);

                    break;


                case "3":
                    ListingActivity listingActivity = new ListingActivity();

                    IntroduceActivity(listingActivity);

                    Console.WriteLine(listingActivity.GetPrompt());
                    AnimateCountdown(listingActivity.GetPauseLength());
                    Console.WriteLine(PlaythroughActivity(listingActivity));

                    FinishActivity(listingActivity);

                    report.SetSeconds(listingActivity);

                    break;


                case "4":
                    Console.Write(report.GetGenerationMessage());
                    AnimateLoading(2);
                    Console.Clear();

                    Console.WriteLine(report.GetReport());
                    Console.Read();
                    AnimateLoading(2);

                    break;


                case "5":
                    // This is the quit case. If the user selects 4 it will enter this case then
                    // exit the loop and end the program.
                    break;


                default:
                    // This default case accounts for a user entry that does not match an item in
                    // the menu. This will tell the user their answer is invalid and return them to
                    // the menu selection.
                    Console.Write("\nInvalid input. Refreshing menu selection screen...");
                    AnimateLoading(2);
                    break;
            }
        } while (menuSelection != "5");

        Console.WriteLine("Goodbye!");
    }
}