namespace ConsoleCityRPG;

public class Building(int coordinateX, int coordinateY)
{
    public int CoordinateX { get; } = coordinateX;
    public int CoordinateY { get; } = coordinateY;
    protected string Role { get; init; } = "Building";

    public virtual void OpenMenu()
    {
        Console.WriteLine($"=== {Role}! ===");
        Console.WriteLine();
        Console.WriteLine("1. Выход");
    }
}