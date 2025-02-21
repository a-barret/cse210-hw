using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a = new Assignment("Aiden Barrett", "Multiplication");
        Console.WriteLine(a.GetSummary()); 

        MathAssignment ma = new MathAssignment("Aiden Barrett", "Multiplication", "7.3", "8-19");
        Console.WriteLine(ma.GetSummary()); 
        Console.WriteLine(ma.GetHomeworkList());

        WritingAssignment wa = new WritingAssignment("Aiden Barrett", "Multiplication", "The Causes of World War II");
        Console.WriteLine(wa.GetSummary()); 
        Console.WriteLine(wa.GetWritingInformation());
    }
}