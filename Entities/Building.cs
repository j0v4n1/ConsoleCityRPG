using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Systems;

namespace ConsoleCityRPG.Entities;

public abstract class Building(int coordinateX, int coordinateY)
{
    public int CoordinateX { get; } = coordinateX;
    public int CoordinateY { get; } = coordinateY;
    public string Name { get; set; } = "Building";
    public string Icon { get; set; } = "🏠";
    public string Interaction { get; set; } = "";

    public virtual void Interact(Player player, EventQueue eventQueue)
    {
        Console.Clear();
        eventQueue.Add(new GameEvent(EventType.ChangeState, GameState.InBuilding));
        eventQueue.Add(new GameEvent(EventType.EnterBuilding, this));
    }
}