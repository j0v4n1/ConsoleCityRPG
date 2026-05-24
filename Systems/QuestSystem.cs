using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Quests;
namespace ConsoleCityRPG.Systems;
public class QuestSystem {
  public void AcceptQuest(Quest quest, Player player) {
    player.AddQuest(quest);
  }
}