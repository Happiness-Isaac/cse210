class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{ShortName}: {Description} ({Points} points)";
    }

    public override string GetStringRepresentation()
    {
        return $"Simple|{ShortName}|{Description}|{Points}|{_isComplete}";
    }

    public bool IsCompleteOverride
    {
        set { _isComplete = value; }
    }
}