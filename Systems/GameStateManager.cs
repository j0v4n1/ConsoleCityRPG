using ConsoleCityRPG.Enum;

namespace ConsoleCityRPG.Systems;

public class GameStateManager
{
    public GameState GameState { get; private set; } = GameState.Exploration;

    public GameStateManager(EventQueue eventQueue)
    {
        eventQueue.OnEventAdded += HandleEvent;
    }

    private void HandleEvent(GameEvent gameEvent)
    {
        if (gameEvent.Type == EventType.ChangeState)
        {
            GameState = (GameState)gameEvent.Payload;
        }
    }
}