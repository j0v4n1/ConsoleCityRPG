namespace ConsoleCityRPG;

public class Game
{
    private const bool IsRunning = true;

    public void Run()
    {
        var player = new Player();
        var map = new Map();
        while (IsRunning)
        {
            Console.CursorVisible = false;
            RenderMap(map);
            RenderPlayer(player.X, player.Y);
            MovePlayer(player, map);
        }
    }

    private void RenderMap(Map map)
    {
        Console.SetCursorPosition(0, 0);
        foreach (var row in map.City) Console.WriteLine(row);
    }

    private void RenderPlayer(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("🙂");
    }

    private void MovePlayer(Player player, Map map)
    {
        var key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.D:
                Console.WriteLine(map.CheckWall(player.X + 1, player.Y));
                Console.ReadKey();
                player.ChangeCoordinates(player.X + 1, player.Y);
                break;
            case ConsoleKey.W:
                Console.WriteLine(map.CheckWall(player.X, player.Y));
                player.ChangeCoordinates(player.X, player.Y - 1);
                break;
            case ConsoleKey.A:
                Console.WriteLine(map.CheckWall(player.X, player.Y));
                player.ChangeCoordinates(player.X - 1, player.Y);
                break;
            case ConsoleKey.S:
                Console.WriteLine(map.CheckWall(player.X, player.Y));
                player.ChangeCoordinates(player.X, player.Y + 1);
                break;
        }
    }
}