using System;
using System.Collections.Generic;   

public class PromptGenerator
{
    public List<string> _prompts;
    private Random _random;
    private string _lastPrompt;

    public PromptGenerator()
    {
        _random = new Random();
        _lastPrompt = "";
        _prompts = new List<string>
        {
            "What is the best thing that happened to you today?",
            "Who made my day today, and how?",
            "If I had one thing i could do over today, what would that be?",
            "Did I extend an helping hand today to any one in need?",
            "What is one thing i learned today?",
            "What is one thing I could have done better today?",
            "How did I see the hand of the Lord in my Life today?",
            "What is one thing I can do to make tomorrow better than today?",
            "What is the strongest emotion I felt today?",
            "Did I say a silent prayer when I needed to?",
        };
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "What is something that stood out to you today?";
        }

        string prompt;
        do
        {
            int index = _random.Next(_prompts.Count);
            prompt = _prompts[index];
        } while (prompt == _lastPrompt && _prompts.Count > 1);

        _lastPrompt = prompt;
        return prompt;

    }
}