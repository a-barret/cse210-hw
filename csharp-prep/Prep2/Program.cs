using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string response = Console.ReadLine();
        int gradepercent = int.Parse(response);

        string letter = "";

        if (gradepercent >= 90)
        {
            string letter = "A";
        }
        else if (gradepercent >= 80)
        {
            string letter = "B";
        }
        else if (gradepercent >= 70)
        {
            string letter = "C";
        }
        else if (gradepercent >= 60)
        {
            string letter = "D";
        }
        else
        {
            string letter = "F";
        }

        Console.WriteLine($"Your letter grade is: {letter}");
        
        if (gradepercent > 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("You did not pass the course. Better luck next time!");
        }
    }
}