namespace ConsoleCityRPG.Quests;
public class Quest(
  string name,
  string description,
  bool isCompleted,
  int reward,
  List<QuestObjective> questObjective) {
  public string Name { get; set; } = name;
  public string Description { get; set; } = description;
  public bool IsCompleted { get; set; } = isCompleted;
  public int Reward { get; set; } = reward;
  public List<QuestObjective> Objectives { get; set; } = questObjective;
}