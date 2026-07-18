using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public int _mood;

    public Entry()
    {
        _date = "";
        _promptText = "";
        _entryText = "";
        _mood = 0;
    }

    public Entry(string date, string promptText, string entryText, int mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    public string GetSaveString()
    {
        return $"{_date}|{_promptText}|{_mood}|{_entryText}";
    }
    public static Entry CreateFromSaveString(string line)
    {
        string[] parts = line.Split("|");

        if (parts.Length >= 4)
        {
            return new Entry(parts[0], parts[1], parts[3], int.Parse(parts[2]));
        }

        return new Entry();

    }
}