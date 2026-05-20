namespace ConsoleCityRPG.Entities;

public class Portal : Building {
  public Portal(int coordinateX, int coordinateY) : base(coordinateX, coordinateY) {
    Name = "Exit";
    Icon = "🏠";
  }
}