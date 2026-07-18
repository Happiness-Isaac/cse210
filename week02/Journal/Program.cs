using System;

// EXCEEDING REQUIREMENTS
// 1. Each entry will as well stores a mood rating (1-5) so the journal 
// captures how the user felt that day, which helps when people feel they 
// have nothing to write about. 

// 2. The menu includes a search option so users can find past entries by keyword. 

// 3. PromptGenerator avoids repeating the same prompt twice in a row, which makes the journal more engaging.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Quit");
            Console.WriteLine("What would you like to do? ");
            Console.Write("");
            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                WriteNewEntry(journal, promptGenerator);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                LoadJournal(journal);
            }
            else if (choice == "4")
            {
                SaveJournal(journal);
            }
            else if (choice == "5")
            {
                SearchJournal(journal);
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a valid option from the menu.");
            }
        }
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        Console.Write("How would you rate your mood today (1-5)? ");
        int mood;

        while (!int.TryParse(Console.ReadLine(), out mood) || mood < 1 || mood > 5)
        {
            Console.Write("Please enter a number between 1 and 5: ");
        }

        string dateText = DateTime.Now.ToShortDateString();
        Entry entry = new Entry(dateText, prompt, response, mood);

        journal.AddEntry(entry);
        Console.WriteLine();
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved.");
        Console.WriteLine();
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("What is the file name? ");
        string filename = Console.ReadLine();

        if (!System.IO.File.Exists(filename))
        {
            Console.WriteLine("File could not be found.");
            Console.WriteLine();
            return;
        }

        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded.");
        Console.WriteLine();

    }

    static void SearchJournal(Journal journal)
    {
        Console.Write("Enter a keyword to search for: ");
        string keyword = Console.ReadLine();
        Console.WriteLine();

        bool found = false;

        foreach (Entry entry in journal._entries)
        {
            if (entry._promptText.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry._entryText.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry._mood.ToString().Contains(keyword) ||
                entry._date.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching entries found.");
        }
        Console.WriteLine();
    }
}