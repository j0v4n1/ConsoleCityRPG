using ConsoleCityRPG.Entities;

namespace ConsoleCityRPG.World;

public class Map {
  public string[] City = [
    "🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱",
    "🧱            🪨                        🧱",
    "🧱            🪨                    🍺  🧱",
    "🧱            🪨                        🧱",
    "🧱            🪨🪨🪨🪨                  🧱",
    "🧱  🪙                                  🧱",
    "🧱                      🪨              🧱",
    "🧱                      🪨              🧱",
    "🧱🪨🪨🪨🪨🪨            🪨              🧱",
    "🧱        🪨            🪨              🧱",
    "🧱                                      🧱",
    "🧱        🏠                            🧱",
    "🧱                                      🌀",
    "🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱"
  ];

  public string[] OpenWorld = [
    "🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱",
    "🌀                                         🧱",
    "🧱                                         🧱",
    "🧱                          👹             🧱",
    "🧱                                         🧱",
    "🧱                                         🧱",
    "🧱                                         🧱",
    "🧱                                         🧱",
    "🧱                                         🧱",
    "🧱                                         🧱",
    "🧱                                         🧱",
    "🧱                                         🧱",
    "🧱                                         🧱",
    "🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱"
  ];

  public bool IsWall(int playerCoordinateX, int playerCoordinateY) {
    return City[playerCoordinateY][playerCoordinateX].ToString() + City[playerCoordinateY][playerCoordinateX + 1] ==
      "🧱" || City[playerCoordinateY][playerCoordinateX].ToString() + City[playerCoordinateY][playerCoordinateX + 1] ==
      "🪨";
  }

  public Building? FindBuildingAt(int playerCoordinateX, int playerCoordinateY, List<Building> buildings) {
    foreach (var building in buildings) {
      if (building.CoordinateX == playerCoordinateX && building.CoordinateY == playerCoordinateY) {
        return building;
      }
    }

    return null;
  }
}