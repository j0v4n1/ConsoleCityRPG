namespace ConsoleCityRPG.Entities;

public class Player(string name, string heroClass) {
  private readonly string _name = name;
  public string HeroClass { get; } = heroClass;
  public int CoordinateY { get; private set; } = 1;
  public int CoordinateX { get; private set; } = 2;
  private int _healthPoints = 100;
  private int _manaPoints = 100;
  private int _gold = 100;
  private int _attackPower = 5;
  private int _defense = 5;

  public void ChangeCoordinates(int newX, int newY) {
    CoordinateX = newX;
    CoordinateY = newY;
  }

  public void ShowPlayerInfo() {
    Console.SetCursorPosition(50, 1);
    Console.WriteLine($"Name: {_name}");
    Console.SetCursorPosition(50, 2);
    Console.WriteLine($"💰 {_gold}");
    Console.SetCursorPosition(50, 3);
    Console.WriteLine($"❤️ {_healthPoints}");
    Console.SetCursorPosition(50, 4);
    Console.WriteLine($"💧 {_manaPoints}");
    Console.SetCursorPosition(50, 5);
    Console.WriteLine($"⚔️ {_attackPower}");
    Console.SetCursorPosition(50, 6);
    Console.WriteLine($"🛡️ {_defense}");
    Console.SetCursorPosition(50, 7);
    if (CoordinateX < 10) {
      Console.SetCursorPosition(50, 7);
      Console.WriteLine($"X =   ");
    }
    Console.SetCursorPosition(50, 7);
    Console.WriteLine($"X = {CoordinateX}");
    if (CoordinateY < 10) {
      Console.SetCursorPosition(50, 8);
      Console.WriteLine($"Y =   ");
    }
    Console.SetCursorPosition(50, 8);
    Console.WriteLine($"Y = {CoordinateY}");
  }
}