using ConsoleCityRPG.Systems;

namespace ConsoleCityRPG.Entities;

public class Shelter : Building
{
    public Shelter(int coordinateX, int coordinateY) : base(coordinateX, coordinateY)
    {
        Name = "Shelter";
        Icon = "🏠";
    }

    private void OpenMenu()
    {
        Console.WriteLine($"=== {Name} {Icon}! ===");
        Console.WriteLine();
        Console.WriteLine("1. Exit");
    }

    public override void Interact(Player player, EventQueue eventQueue)
    {
        base.Interact(player, eventQueue);
        OpenMenu();
    }
}