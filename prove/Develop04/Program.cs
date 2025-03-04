// For my exceeding requiements fulfillment, I created report functionality to my program. I did
// this by first creating a "Report.cs" file. This contains the "Report" class. The class keeps
// a record of the number of seconds each activity is done for as well as the total number of
// seconds any activity is done for. The user can select to view a report of the time spent in
// activities.

// I also added the case in the main menu for if the user enters an option or anything that doesn't
// show up in the menu. It will reset the menu for them to enter a selection again.

// Added a goodbye message to after the user select "quit" in the menu.

using System;

class Program
{
    static void Main(string[] args)
    {
        string menuSelection;

        Report report = new Report();

        // This function prints the menu to the screen before the user is prompted to select.
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

        // This function will create the "spinning stick" animation for the number of seconds
        // passed into the function.
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

        // Creates an animated timer counting down to 0 from the number passed in as an argument.
        static void AnimateCountdown(int duration)
        {
            for (int i = duration; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // The consistent process used by all activities to introduce it to the user. It gets user
        // duration input as well.
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

        // This set of actions is consistent across the types of activities the user might select.
        static void FinishActivity(Activity activity)
        {
            Console.WriteLine(activity.GetCompleteMessage());
            AnimateLoading(activity.GetPauseLength());
            Console.WriteLine();
            Console.WriteLine(activity.GetExitMessage());
            AnimateLoading(activity.GetPauseLength());
        }

        // Beginning of the main program loop.
        do
        {
            Menu();
            menuSelection = Console.ReadLine();

            // Opens up to the various menu selections a user might have made.
            // The options are 1,2,3,4,5 and if they enter anything else it will refresh the menu.
            switch (menuSelection)
            {
                case "1":
                    // Case facilitates the breathing activity.
                    BreathingActivity breathingActivity = new BreathingActivity();

                    IntroduceActivity(breathingActivity);

                    DateTime endTimeBreath = DateTime.Now.AddSeconds(breathingActivity.GetDuration());
                    while (DateTime.Now < endTimeBreath)
                    {
                        Console.Write(breathingActivity.GetBreathMessage());
                        AnimateCountdown(breathingActivity.GetBreathDuration());
                        Console.WriteLine();
                    }

                    FinishActivity(breathingActivity);

                    report.SetSeconds(breathingActivity);

                    break;


                case "2":
                    // Case facilitates the reflection activity.
                    ReflectionActivity reflectionActivity = new ReflectionActivity();

                    IntroduceActivity(reflectionActivity);

                    Console.WriteLine(reflectionActivity.GetPrompt());
                    Console.ReadLine();

                    Console.Write(reflectionActivity.GetReflectionPrepMessage());
                    AnimateCountdown(reflectionActivity.GetPauseLength());
                    Console.Clear();

                    DateTime endTimeReflect = DateTime.Now.AddSeconds(reflectionActivity.GetDuration());
                    while (DateTime.Now < endTimeReflect)
                    {
                        Console.Write(reflectionActivity.GetQuestion());
                        AnimateLoading(reflectionActivity.GetReflectionDuration());
                        Console.WriteLine();
                    }

                    FinishActivity(reflectionActivity);

                    report.SetSeconds(reflectionActivity);

                    break;


                case "3":
                    // Case facilitates the listing activity.
                    ListingActivity listingActivity = new ListingActivity();

                    IntroduceActivity(listingActivity);

                    Console.WriteLine(listingActivity.GetPrompt());
                    AnimateCountdown(listingActivity.GetPauseLength());

                    DateTime endTimeList = DateTime.Now.AddSeconds(listingActivity.GetDuration());
                    while (DateTime.Now < endTimeList)
                    {
                        Console.Write(listingActivity.GetEntryPoint());
                        Console.ReadLine();
                        listingActivity.SetItemsListed(listingActivity.GetItemsListed() + 1);
                    }
                    Console.WriteLine(listingActivity.GetListingReport());

                    FinishActivity(listingActivity);

                    report.SetSeconds(listingActivity);

                    break;


                case "4":
                    // Case facilitates the activity report generation.
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

        Console.Clear();
        Console.WriteLine("Goodbye!");
    }
}