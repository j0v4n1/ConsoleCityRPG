using ConsoleCityRPG.Core;
using ConsoleCityRPG.Enum;

namespace ConsoleCityRPG.Entities;

public class Building(int coordinateX, int coordinateY) {
  public int CoordinateX { get; } = coordinateX;
  public int CoordinateY { get; } = coordinateY;
  protected string Name { get; init; } = "Building";
  public string Icon { get; init; } = "🏠";

  public virtual void OpenMenu() {
    Console.Clear();
    Game.ChangeGameState(GameState.InBuilding);
    Console.WriteLine($"=== {Name}! ===");
    Console.WriteLine();
    Console.WriteLine("1. Выход");
  }
}