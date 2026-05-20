namespace ConsoleCityRPG.Entities;

public class Shelter : Building {
  public Shelter(int coordinateX, int coordinateY) : base(coordinateX, coordinateY) {
    Name = "Shelter";
    Icon = "🏠";
  }
}