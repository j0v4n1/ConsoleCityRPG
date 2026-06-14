namespace ConsoleCityRPG.Entities;

public class Monster(Position position, string name)
{
    public Position Position { get; set; } = position;
    public string Name { get; set; } = name;
    public char Icon { get; set; } = 'M';
    public int Health { get; private set; } = 15;
    public int AttackPower { get; private set; } = 5;
    public int Initiative { get; private set; } = 5;
    public int Defense { get; private set; } = 10;

    public void OnAttacked(int attackPower)
    {
        Health -= attackPower;
    }
}