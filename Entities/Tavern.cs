namespace ConsoleCityRPG.Entities;

public class Tavern : Building {
  public Tavern(int coordinateX, int coordinateY) : base(coordinateX, coordinateY) {
    Name = "Tavern";
    Icon = "🍺";
  }

  public override void OpenMenu() {
    base.OpenMenu();
    Console.WriteLine("2. Взять квест");
  }
}