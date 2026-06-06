using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Systems;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Entities;

public class Portal : Building
{
    private Map TargetMap { get; }
    private int TargetX { get; }
    private int TargetY { get; }

    public Portal(int coordinateX, int coordinateY, Map targetMap, int targetX,
        int targetY) : base(coordinateX, coordinateY)
    {
        Name = "Portal";
        TargetMap = targetMap;
        TargetX = targetX;
        TargetY = targetY;
    }

    public override void Interact(Player player, EventQueue eventQueue)
    {
        eventQueue.Add(new GameEvent(EventType.SwitchWorld, TargetMap));
        player.ChangeCoordinates(TargetX, TargetY);
    }
}