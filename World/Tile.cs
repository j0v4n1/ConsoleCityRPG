namespace ConsoleCityRPG.World;

public class Tile(char symbol, bool isWalkable)
{
    public char Symbol { get; } = symbol;
    public bool IsWalkable { get; } = isWalkable;
}