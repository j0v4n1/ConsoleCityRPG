namespace ConsoleCityRPG.Entities;

public class Shop : Building {
  public Shop(int coordinateX, int coordinateY) : base(coordinateX, coordinateY) {
    Name = "Shop";
    Icon = "🪙";
  }
}