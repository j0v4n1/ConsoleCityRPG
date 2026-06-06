using ConsoleCityRPG.Systems;

namespace ConsoleCityRPG.Entities;

public class Shop : Building
{
    public Shop(int coordinateX, int coordinateY) : base(coordinateX, coordinateY)
    {
        Name = "Shop";
        Icon = "🪙";
    }

    private void OpenMenu()
    {
        Console.WriteLine($"=== {Name} {Icon}! ===");
        Console.WriteLine();
        Console.WriteLine("1. Buy an item");
        Console.WriteLine("2. Exit");
    }

    public override void Interact(Player player, EventQueue eventQueue)
    {
        base.Interact(player, eventQueue);
        OpenMenu();
    }
}