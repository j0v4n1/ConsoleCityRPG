namespace ConsoleCityRPG.Systems;
public class EventQueue {
  private readonly List<GameEvent> _events = [];
  public void Add(GameEvent gameEvent) {
    _events.Add(gameEvent);
  }
  public List<GameEvent> GetAll() {
    return _events;
  }
  public void Clear() {
    _events.Clear();
  }
}