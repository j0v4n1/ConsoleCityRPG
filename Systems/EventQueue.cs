namespace ConsoleCityRPG.Systems;
public class EventQueue {
  public event Action<GameEvent>? OnEventAdded;
  public void Add(GameEvent gameEvent) {
    OnEventAdded?.Invoke(gameEvent);
  }
}