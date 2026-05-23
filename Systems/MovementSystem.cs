using ConsoleCityRPG.Entities;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Systems;

public class MovementSystem(EventQueue eventQueue) {
  private void TryMove(Player player, Map map, List<Building> buildings,
    int deltaX, int deltaY) {
    if (map.IsWalkableTile(player.CoordinateX + deltaX,
          player.CoordinateY + deltaY)) {
      map.FindBuildingAt(player.CoordinateX + deltaX,
        player.CoordinateY + deltaY, buildings)?.Interact(player, eventQueue);
      player.ChangeCoordinates(player.CoordinateX + deltaX,
        player.CoordinateY + deltaY);
    }
  }

  public void Update(Player player, Map map, List<Building> buildings,
    ConsoleKeyInfo key) {
    switch (key.Key) {
      case ConsoleKey.D:
        TryMove(player, map, buildings, 1, 0);
        break;
      case ConsoleKey.W:
        TryMove(player, map, buildings, 0, -1);
        break;
      case ConsoleKey.A:
        TryMove(player, map, buildings, -1, 0);
        break;
      case ConsoleKey.S:
        TryMove(player, map, buildings, 0, 1);
        break;
    }
  }
}