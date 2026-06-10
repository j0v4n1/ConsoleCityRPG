namespace ConsoleCityRPG.Entities;

public class Tavern : Building
{
    public Tavern(int coordinateX, int coordinateY) :
        base(coordinateX, coordinateY)
    {
        Name = "Таверна";
        Icon = "🍺";
        Interaction = "Взять квест";
    }
}