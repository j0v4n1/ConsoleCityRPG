namespace ConsoleCityRPG;

public class Game {
  private bool _isRunning = true;

  public void Run() {
    ConsoleMessage.WellcomeMessage();
    ConsoleMessage.NameCharacterMessage();
    string? name = Console.ReadLine();
    while (name == null) {
      Console.Clear();
      ConsoleMessage.WellcomeMessage();
      ConsoleMessage.NameCharacterMessage();
      name = Console.ReadLine();
    }

    ConsoleMessage.ChooseClassCharacterMessage();
    string? heroClass = Console.ReadLine();
    while (heroClass != "1" && heroClass != "2" && heroClass != "3") {
      ConsoleMessage.ChooseClassCharacterMessage();
      heroClass = Console.ReadLine();
    }

    heroClass = heroClass switch {
      "1" => "🧝‍♂️",
      "2" => "🧙‍♂️",
      "3" => "🥷",
      _ => heroClass
    };

    var player = new Player(name, heroClass);
    var map = new Map();
    var tavern = new Tavern(36, 4);
    var shop = new Shop(7, 4);
    var shelter = new Shelter(19, 11);
    var exit = new Building(30, 12);

    List<Building> buildings = [tavern, shop, shelter, exit];
    Console.Clear();
    Console.SetCursorPosition(50, 0);
    while (_isRunning) {
      Console.CursorVisible = false;
      RenderMap(map);
      RenderPlayer(player.CoordinateX, player.CoordinateY, player.HeroClass);
      player.ShowPlayerInfo();
      MovePlayer(player, map, buildings);
    }
  }

  // private void GameOver() {
  //   Console.Clear();
  //   _isRunning = false;
  // }

  private void RenderMap(Map map) {
    Console.SetCursorPosition(0, 0);
    foreach (var row in map.City) {
      Console.WriteLine(row);
    }
  }

  private void RenderPlayer(int x, int y, string playerAvatar) {
    Console.SetCursorPosition(x, y);
    Console.Write(playerAvatar);
  }

  private void SearchingBuilding(Player player, List<Building> buildings, int deltaX, int deltaY) {
    foreach (var building in buildings.Where(building =>
               building.CoordinateX == player.CoordinateX + deltaX &&
               building.CoordinateY == player.CoordinateY + deltaY)) {
      Console.Clear();
      building.OpenMenu();
    }
  }

  private void TryMove(Player player, Map map, List<Building> buildings, int deltaX, int deltaY) {
    if (map.IsDoor(player.CoordinateX + deltaX, player.CoordinateY + deltaY)) {
      SearchingBuilding(player, buildings, deltaX, deltaY);
    }

    if (map.IsWall(player.CoordinateX + deltaX, player.CoordinateY + deltaY)) {
      return;
    }

    player.ChangeCoordinates(player.CoordinateX + deltaX, player.CoordinateY + deltaY);
  }

  private void MovePlayer(Player player, Map map, List<Building> buildings) {
    var key = Console.ReadKey();
    switch (key.Key) {
      case ConsoleKey.D:
        TryMove(player, map, buildings, 2, 0);
        break;
      case ConsoleKey.W:
        TryMove(player, map, buildings, 0, -1);
        break;
      case ConsoleKey.A:
        TryMove(player, map, buildings, -2, 0);
        break;
      case ConsoleKey.S:
        TryMove(player, map, buildings, 0, 1);
        break;
    }
  }
}