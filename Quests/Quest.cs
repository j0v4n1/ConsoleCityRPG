namespace ConsoleCityRPG.Quests;

public class Quest(
    string name,
    string description,
    int reward,
    List<QuestObjective> questObjective)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public bool IsCompleted { get; set; } = false;
    public int Reward { get; set; } = reward;
    public List<QuestObjective> Objectives { get; set; } = questObjective;
}