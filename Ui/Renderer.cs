using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Systems;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Ui;

public class Renderer
{
    private void RenderMap(Map map, string[] mapTiles)
    {
        Console.SetCursorPosition(0, 0);
        for (int y = 0; y < mapTiles.Length; y++)
        {
            for (int x = 0; x < mapTiles[y].Length; x++)
            {
                Console.Write(map.GetTile(x, y).Symbol);
            }

            Console.WriteLine();
        }
    }

    private void RenderPlayer(int x, int y, char player)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(player);
    }

    private void RenderMonsters(MapManager mapManager)
    {
        foreach (var monster in mapManager.Monsters)
        {
            Console.SetCursorPosition(monster.Position.X, monster.Position.Y);
            Console.WriteLine(monster.Icon);
        }
    }

    public void Render(MapManager mapManager, Player player)
    {
        RenderMap(mapManager.CurrentGameMap, mapManager.CurrentGameMap.MapTiles);

        if (mapManager.CurrentGameMap.MapTiles == MapData.World &&
            mapManager.Monsters.Count > 0)
        {
            RenderMonsters(mapManager);
        }

        RenderPlayer(player.CoordinateX, player.CoordinateY, Player.HeroIcon);
    }
}