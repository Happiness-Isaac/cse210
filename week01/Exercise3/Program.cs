using System;

class Program
{
    static void Main(string[] args)
    {
       
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Guess higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Guess lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");
                }
            }

            Console.Write("Do yu wish to play again? (yes/no) ");
            playAgain = Console.ReadLine();

        }

        Console.WriteLine("Thank you for playing");

    }
}