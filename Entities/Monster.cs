namespace ConsoleCityRPG.Entities;

public class Monster(Position position, string name)
{
    public Position Position { get; set; } = position;
    public string Name { get; set; } = name;
    public char Icon { get; set; } = 'M';
    public int Health { get; private set; } = 15;
    public int Attack { get; private set; } = 5;
}