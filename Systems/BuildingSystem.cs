using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;

namespace ConsoleCityRPG.Systems;

public class BuildingSystem
{
    private Building? _currentBuilding;

    public BuildingSystem(EventQueue eventQueue)
    {
        eventQueue.OnEventAdded += HandleEvent;
    }

    private void HandleEvent(GameEvent gameEvent)
    {
        if (gameEvent.Type == EventType.EnterBuilding)
        {
            _currentBuilding = (Building?)gameEvent.Payload;
        }
    }

    public void Update(EventQueue eventQueue)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"== {_currentBuilding?.Name} {_currentBuilding?.Icon}! ==");
        Console.WriteLine();
        Console.WriteLine($"1. {_currentBuilding?.Interaction}");
        Console.WriteLine("2. Выход");
        var key = Console.ReadLine();
        switch (key)
        {
            case "1":
                switch (_currentBuilding)
                {
                    case Tavern:
                        eventQueue.Add(new GameEvent(EventType.QuestAccepted));
                        break;
                    case Shop:
                        return;
                    case Shelter:
                        return;
                }

                eventQueue.Add(new GameEvent(EventType.ChangeState, GameState.Exploration));
                break;
            case "2":
                eventQueue.Add(new GameEvent(EventType.ChangeState, GameState.Exploration));
                break;
        }
    }
}