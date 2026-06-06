namespace ConsoleCityRPG.Entities;

public class Monster
{
    public Position Position { get; set; }

    public Monster(Position position)
    {
        Position = position;
    }
}