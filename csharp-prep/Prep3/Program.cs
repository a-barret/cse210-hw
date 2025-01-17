using System;

class Program
{
    static void Main(string[] args)
    {

        // Console.WriteLine("What is the magic number? ");
        // int magicnumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,101);

        int guess;

        do
        {
            
            Console.WriteLine("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        } while (guess != number);

    }
}