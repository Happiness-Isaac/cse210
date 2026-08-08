class Goal
{
    public string ShortName { get; }
    protected string Description { get; }
    protected int Points { get; }

    public Goal(string shortName, string description, int points)
    {
        ShortName = shortName;
        Description = description;
        Points = points;
    }

    public virtual int RecordEvent()
    {
        return 0;
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {
        return $"{ShortName}: {Description} ({Points} points)";
    }

    public virtual string GetStringRepresentation()
    {
        return $"Goal|{ShortName}|{Description}|{Points}";
    }
}