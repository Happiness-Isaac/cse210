using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("");

        WritingAssignment writingAssignment1 = new WritingAssignment("Jimbo", "Fiction", "Creative writing");
        WritingAssignment writingAssignment2 = new WritingAssignment("John", "Science Fiction", "Alien visitation");
        WritingAssignment writingAssignment3 = new WritingAssignment("Jerry", "Historical Fiction", "Life during the Great Depression");

        Console.WriteLine(writingAssignment1.GetSummary() + " - " + writingAssignment1.GetWritingInformation());
        Console.WriteLine(writingAssignment2.GetSummary() + " - " + writingAssignment2.GetWritingInformation());
        Console.WriteLine(writingAssignment3.GetSummary() + " - " + writingAssignment3.GetWritingInformation());

        Console.WriteLine();
        MathAssignment mathAssignment1 = new MathAssignment("Marry", "Fractions", "5.2", "1-6");
        MathAssignment mathAssignment2 = new MathAssignment("Maddy", "Arrithmatic", "9.1", "1-3");
        MathAssignment mathAssignment3 = new MathAssignment("Minnie", "Quadratic Formulas", "7.4", "9-23");

        Console.WriteLine(mathAssignment1.GetSummary() + " - " + mathAssignment1.GetHomeworkList());
        Console.WriteLine(mathAssignment2.GetSummary() + " - " + mathAssignment2.GetHomeworkList());
        Console.WriteLine(mathAssignment3.GetSummary() + " - " + mathAssignment3.GetHomeworkList());

    }
}