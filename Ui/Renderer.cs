using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Systems;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Ui;

public class Renderer {
  private void DrawMap(Map map, string[] mapTiles) {
    Console.SetCursorPosition(0, 0);

    for (int y = 0; y < mapTiles.Length; y++) {
      for (int x = 0; x < mapTiles[y].Length; x++) {
        Console.Write(map.GetTile(x, y).Symbol);
      }

      Console.WriteLine();
    }
  }

  private void DrawPlayer(int x, int y, char player) {
    Console.SetCursorPosition(x, y);
    Console.Write(player);
  }

  public void Render(Map map, MapManager mapManager, Player player) {
    DrawMap(mapManager.CurrentGameMap, mapManager.CurrentGameMap.MapTiles);
    DrawPlayer(player.CoordinateX, player.CoordinateY, player.HeroClass);
  }
}