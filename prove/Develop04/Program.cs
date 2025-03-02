using System;

class Program
{
    static void Main(string[] args)
    {
        string menuSelection;

        static void Menu()
        {
            Console.Clear();
            Console.Write(@"Menu Options:
  1. Start Breathing Activity
  2. Start Reflecting Activity
  3. Start Listing Activity
  4. Quit
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
                if (activity is BreathingActivity breathingActivity) {
                    Console.Write(breathingActivity.GetBreathMessage());
                    AnimateCountdown(breathingActivity.GetBreathDuration());
                    Console.WriteLine();
                } else if (activity is ReflectionActivity reflectionActivity) {
                    Console.Write(reflectionActivity.GetQuestion() + " ");
                    AnimateLoading(reflectionActivity.GetReflectionDuration());
                    Console.WriteLine();
                } else if (activity is ListingActivity) {
                    Console.Write("> ");
                    Console.ReadLine();
                    itemsListed += 1;
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

        do {
            Menu();
            menuSelection = Console.ReadLine();

            switch (menuSelection)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();

                    IntroduceActivity(breathingActivity);

                    PlaythroughActivity(breathingActivity);

                    FinishActivity(breathingActivity);

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

                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();

                    IntroduceActivity(listingActivity);

                    Console.WriteLine(listingActivity.GetPrompt());
                    AnimateCountdown(listingActivity.GetPauseLength());
                    Console.WriteLine(PlaythroughActivity(listingActivity));
                    
                    FinishActivity(listingActivity);

                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (menuSelection != "4");
    }
}