class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;
        int reward = Points;
        if (IsComplete())
        {
            reward += _bonus;
        }

        return reward;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist|{ShortName}|{Description}|{Points}|{_amountCompleted}|{_target}|{_bonus}";
    }

    public override string GetDetailsString()
    {
        return $"{ShortName}: {Description} ({Points} points) - {_amountCompleted}/{_target} completed";
    }

    public int AmountCompleted
    {
        set { _amountCompleted = value; }
    }
}