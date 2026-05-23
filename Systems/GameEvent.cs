using ConsoleCityRPG.Enum;

namespace ConsoleCityRPG.Systems;

public class GameEvent(EventType type, object? payload = null) {
  public EventType Type { get; } = type;
  public object? Payload { get; } = payload;
}