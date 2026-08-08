class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"{ShortName}: {Description} ({Points} points)";
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal|{ShortName}|{Description}|{Points}";
    }
}