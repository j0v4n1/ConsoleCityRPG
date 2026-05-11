namespace ConsoleCityRPG;

public class Game
{
    private readonly bool _isRunning = true;

    public void Run()
    {
        var map = new Map();
        while (_isRunning) map.RenderMap();
    }
}