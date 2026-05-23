using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Quests;

namespace ConsoleCityRPG.Services;

public class QuestSystem {
  public void AcceptQuest(Quest quest, Player player) {
    player.AddQuest(quest);
  }
}