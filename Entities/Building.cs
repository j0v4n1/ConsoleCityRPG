using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Systems;

namespace ConsoleCityRPG.Entities;

public abstract class Building(int coordinateX, int coordinateY)
{
    public int CoordinateX { get; } = coordinateX;
    public int CoordinateY { get; } = coordinateY;
    protected string Name { get; init; } = "Building";
    protected string Icon { get; init; } = "🏠";

    public virtual void Interact(Player player, EventQueue eventQueue)
    {
        Console.Clear();
        eventQueue.Add(new GameEvent(EventType.ChangeState, GameState.InBuilding));
    }
}