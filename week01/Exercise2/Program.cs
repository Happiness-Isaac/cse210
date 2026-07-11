using System;

class Program
{
    static void Main(string[] args)
    {
        // Asking user for grade perscentage
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = percent % 10;
        string sign;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // no A+, only A an A-
        if (letter == "A")
        {
            if (lastDigit < 3 && percent < 100)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }

        //no F+/-, only F
        if (letter == "F")
        {
            sign = "";
        }

        // Determine if user passes or not
        Console.WriteLine($"Your grade is : {letter}{sign}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratlations. You made it! 🎉");
        }
        else
        {
            Console.WriteLine("You can do better next term ! 👍");
            
        }
    }
}