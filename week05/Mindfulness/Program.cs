using System;
// EXCEEDING REQIREMENT
// Creative enhancement: track how many times each type of activity is completed during this session.

class Program
{
    static void Main(string[] args)
    {

        int breathingCount = 0;
        int listingCount = 0;
        int reflectionCount = 0;
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflection Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    breathingCount++;
                    break;
                case "2":
                    new ListingActivity().Run();
                    listingCount++;
                    break;
                case "3":
                    new ReflectionActivity().Run();
                    reflectionCount++;
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }

        Console.WriteLine();
        Console.WriteLine("Session Summary:");
        Console.WriteLine($"- Breathing activity completed: {breathingCount} time(s)");
        Console.WriteLine($"- Listing activity completed: {listingCount} time(s)");
        Console.WriteLine($"- Reflection activity completed: {reflectionCount} time(s)");
        Console.WriteLine("Thank you for practicing mindfulness today.");
    }
}