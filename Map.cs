namespace ConsoleCityRPG;

public class Map {
  public string[] City = [
    "🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱",
    "🧱            🪨                        🧱",
    "🧱            🪨                    🍺  🧱",
    "🧱            🪨                        🧱",
    "🧱            🪨🪨🪨🪨                  🧱",
    "🧱  🏪                                  🧱",
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
    return City[playerCoordinateY][playerCoordinateX].ToString() + 
      City[playerCoordinateY][playerCoordinateX + 1] == "🧱" || 
      City[playerCoordinateY][playerCoordinateX].ToString() + 
      City[playerCoordinateY][playerCoordinateX + 1] == "🪨";
  }

  public bool IsDoor(int playerCoordinateX, int playerCoordinateY) {
    return City[playerCoordinateY][playerCoordinateX] == '▓';
  }
}