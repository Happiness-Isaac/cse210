using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private string _file = "goals.txt";

    public void Start()
    {
        LoadGoals();

        while (true)
        {
            Console.WriteLine("1. List Goals");
            Console.WriteLine("2. Create Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Display Info");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string command = Console.ReadLine();

            if (command == "1")
            {
                ListGoals();
            }
            else if (command == "2")
            {
                CreateGoal();
            }
            else if (command == "3")
            {
                RecordEvent();
            }
            else if (command == "4")
            {
                SaveGoals();
            }
            else if (command == "5")
            {
                LoadGoals();
            }
            else if (command == "6")
            {
                DisplayInfo();
            }
            else if (command == "7")
            {
                SaveGoals();
                break;
            }
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Score: " + _score);
        Console.WriteLine("Goals: " + _goals.Count);
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string mark = "[ ]";

            if (goal.IsComplete())
            {
                mark = "[X]";
            }

            Console.WriteLine((i + 1) + ". " + mark + " " + goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Type: 1=Simple 2=Eternal 3=Checklist");
        string typeInput = Console.ReadLine();

        Console.Write("name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("desc: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("points: ");
        string pointsInput = Console.ReadLine();
        int points;
        if (!int.TryParse(pointsInput, out points))
        {
            points = 0;
        }

        if (typeInput == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeInput == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (typeInput == "3")
        {
            Console.Write("target: ");
            string targetInput = Console.ReadLine();
            int target;
            if (!int.TryParse(targetInput, out target))
            {
                target = 1;
            }

            Console.Write("bonus: ");
            string bonusInput = Console.ReadLine();
            int bonus;
            if (!int.TryParse(bonusInput, out bonus))
            {
                bonus = 0;
            }

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.Write("which: ");
        string which = Console.ReadLine();
        int index;
        if (!int.TryParse(which, out index))
        {
            return;
        }

        if (index < 1 || index > _goals.Count)
        {
            return;
        }

        Goal selectedGoal = _goals[index - 1];
        int awardedPoints = selectedGoal.RecordEvent();
        _score = _score + awardedPoints;
    }

    public void SaveGoals()
    {
        List<string> lines = new List<string>();
        lines.Add("Score|" + _score);

        for (int i = 0; i < _goals.Count; i++)
        {
            lines.Add(_goals[i].GetStringRepresentation());
        }

        File.WriteAllLines(_file, lines);
    }

    public void LoadGoals()
    {
        if (!File.Exists(_file))
        {
            return;
        }

        _goals.Clear();
        _score = 0;

        string[] lines = File.ReadAllLines(_file);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split('|');

            if (parts.Length == 0)
            {
                continue;
            }

            if (parts[0] == "Score")
            {
                int savedScore;
                if (parts.Length >= 2 && int.TryParse(parts[1], out savedScore))
                {
                    _score = savedScore;
                }

                continue;
            }

            if (parts[0] == "Simple" && parts.Length >= 5)
            {
                int simplePoints;
                if (!int.TryParse(parts[3], out simplePoints))
                {
                    simplePoints = 0;
                }

                SimpleGoal simpleGoal = new SimpleGoal(parts[1], parts[2], simplePoints);

                bool isComplete;
                if (bool.TryParse(parts[4], out isComplete))
                {
                    simpleGoal.IsCompleteOverride = isComplete;
                }

                _goals.Add(simpleGoal);
            }
            else if (parts[0] == "Eternal" && parts.Length >= 4)
            {
                int eternalPoints;
                if (!int.TryParse(parts[3], out eternalPoints))
                {
                    eternalPoints = 0;
                }

                _goals.Add(new EternalGoal(parts[1], parts[2], eternalPoints));
            }
            else if (parts[0] == "Checklist" && parts.Length >= 7)
            {
                int checklistPoints;
                if (!int.TryParse(parts[3], out checklistPoints))
                {
                    checklistPoints = 0;
                }

                int checklistCompleted;
                if (!int.TryParse(parts[4], out checklistCompleted))
                {
                    checklistCompleted = 0;
                }

                int checklistTarget;
                if (!int.TryParse(parts[5], out checklistTarget))
                {
                    checklistTarget = 1;
                }

                int checklistBonus;
                if (!int.TryParse(parts[6], out checklistBonus))
                {
                    checklistBonus = 0;
                }

                ChecklistGoal checklistGoal = new ChecklistGoal(parts[1], parts[2], checklistPoints, checklistTarget, checklistBonus);
                checklistGoal.AmountCompleted = checklistCompleted;
                _goals.Add(checklistGoal);
            }
        }
    }
}