using System;

class Program
{
    static void Main(string[] args)
    {   
        Scripture scripture = new Scripture();
        Reference reference = new Reference();
        List<Word> words = scripture.GetWords();

        int blankCount;
        string userInput;

        do {
            blankCount = 0;

            Console.Clear();

            string scriptureText = "";
            foreach (Word w in words) {
                if (w.GetIsBlank() == false) {
                    scriptureText += w.GetWord() + " ";
                } else {
                    blankCount += 1;
                    scriptureText += w.GetBlank() + " ";
                }
            }
            
            Console.WriteLine($@"{reference.GetReference()}
{scriptureText}");
            
            Random random = new Random();
            int max = Math.Min(5, words.Count - blankCount);
            int numberOfNewBlanks = random.Next(0,max) + 1;
            for (int i = 0; i < numberOfNewBlanks; i++) {
                if (words.Count - blankCount > 0) {
                    Console.WriteLine($"Iteration: {i}");
                    restart:
                    int newBlank = random.Next(0,words.Count);
                    if (words[newBlank].GetIsBlank() == false){
                        words[newBlank].SetIsBlank(true);
                        Console.WriteLine($"{words[newBlank].GetWord()} set to blank.");
                        numberOfNewBlanks -= 1;
                    } else {
                        Console.WriteLine("Restarting random loop.");
                        goto restart;
                    }
                } else {
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type \"quit\" to finish:");
            userInput = Console.ReadLine();
        } while (blankCount < words.Count && userInput.ToLower() != "quit");
    }
}