namespace ConsoleCityRPG;

public class Tavern : Building
{
    public Tavern(int coordinateX, int coordinateY) : base(coordinateX, coordinateY)
    {
        Role = "Tavern";
    }

    public override void OpenMenu()
    {
        base.OpenMenu();
        Console.WriteLine("2. Взять квест");
    }
}