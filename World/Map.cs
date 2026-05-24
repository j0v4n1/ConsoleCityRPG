using ConsoleCityRPG.Entities;
namespace ConsoleCityRPG.World;
public class Map(string[] mapTiles) {
  public string[] MapTiles { get; } = mapTiles;
  public List<Building> Buildings { get; private set; } = [];
  public bool IsWalkableTile(int playerCoordinateX, int playerCoordinateY) {
    return GetTile(playerCoordinateX, playerCoordinateY).IsWalkable;
  }
  public Building?
    FindBuildingAt(int playerCoordinateX, int playerCoordinateY) {
    foreach (var building in Buildings) {
      if (building.CoordinateX == playerCoordinateX &&
          building.CoordinateY == playerCoordinateY) {
        return building;
      }
    }
    return null;
  }
  public Tile GetTile(int x, int y) {
    char symbol = MapTiles[y][x];
    return symbol switch {
      '#' => new Tile('#', false),
      '.' => new Tile('.', true),
      _ => new Tile(symbol, true)
    };
  }
  public void SetBuildings(List<Building> buildings) {
    Buildings = buildings;
  }
}