namespace ConsoleCityRPG.Quests;

public class QuestObjective(string description, int current, int required)
{
    public string Description { get; set; } = description;
    public int Current { get; set; } = current;
    public int Required { get; set; } = required;
    public bool IsCompleted => Current >= Required;
}