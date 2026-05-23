using ConsoleCityRPG.Entities;

namespace ConsoleCityRPG.World;

public class Map(string[] mapTiles) {
  public string[] MapTiles { get; } = mapTiles;

  public bool IsWalkableTile(int playerCoordinateX, int playerCoordinateY) {
    return GetTile(playerCoordinateX, playerCoordinateY).IsWalkable;
  }

  public Building? FindBuildingAt(int playerCoordinateX, int playerCoordinateY,
    List<Building> buildings) {
    foreach (var building in buildings) {
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
}