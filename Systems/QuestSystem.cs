using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Quests;

namespace ConsoleCityRPG.Systems;

public class QuestSystem
{
    private readonly Player _player;
    private readonly EventQueue _eventQueue;

    public QuestSystem(Player player, EventQueue eventQueue)
    {
        _player = player;
        _eventQueue = eventQueue;

        eventQueue.OnEventAdded += HandleEvent;
    }

    private void HandleEvent(GameEvent gameEvent)
    {
        if (gameEvent.Type == EventType.QuestAccepted)
        {
            var quest = CreateQuest();
            _player.AddQuest(quest);
            _eventQueue.Add(new GameEvent(EventType.SpawnMonster, "Крыса"));
        }
    }

    private Quest CreateQuest()
    {
        return new Quest("Помочь трактирщику",
            "Трактирщик попросил Вас помочь ему избавить от крыс", 50,
            [new QuestObjective("Убить 5 крыс", 0, 5)]);
    }
}