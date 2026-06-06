using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Quests;

namespace ConsoleCityRPG.Systems;

public class QuestSystem
{
    public void AcceptQuest(Quest quest, Player player, EventQueue eventQueue)
    {
        player.AddQuest(quest);
        eventQueue.Add(new GameEvent(EventType.QuestAccepted));
    }
}