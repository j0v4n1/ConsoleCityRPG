using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Systems;

public class MovementSystem(EventQueue eventQueue)
{
    private void TryMove(Player player, Map map, int deltaX, int deltaY, MapManager mapManager)
    {
        var monster = mapManager.Monsters.FirstOrDefault(m =>
            m.Position.X == player.CoordinateX + deltaX && m.Position.Y == player.CoordinateY + deltaY);

        if (monster != null)
        {
            eventQueue.Add(new GameEvent(EventType.ChangeState, GameState.Combat));
            eventQueue.Add(new GameEvent(EventType.EnterCombat, monster));
        }

        if (map.IsWalkableTile(player.CoordinateX + deltaX,
                player.CoordinateY + deltaY))
        {
            map.FindBuildingAt(player.CoordinateX + deltaX,
                player.CoordinateY + deltaY)?.Interact(player, eventQueue);

            player.ChangeCoordinates(player.CoordinateX + deltaX,
                player.CoordinateY + deltaY);
        }
    }

    public void Update(Player player, Map map, ConsoleKeyInfo key, MapManager mapManager)
    {
        switch (key.Key)
        {
            case ConsoleKey.D:
                TryMove(player, map, 1, 0, mapManager);
                break;
            case ConsoleKey.W:
                TryMove(player, map, 0, -1, mapManager);
                break;
            case ConsoleKey.A:
                TryMove(player, map, -1, 0, mapManager);
                break;
            case ConsoleKey.S:
                TryMove(player, map, 0, 1, mapManager);
                break;
        }
    }
}