using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Ui;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Core;

public class Game {
  private bool _isRunning = true;
  private static GameState _gameState = GameState.Exploration;

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
    var tavern = new Tavern(36, 2);
    var shop = new Shop(4, 5);
    var shelter = new Shelter(10, 11);
    var portal = new Portal(40, 12);

    List<Building> buildings = [tavern, shop, shelter, portal];
    Console.Clear();
    Console.SetCursorPosition(50, 0);
    while (_isRunning) {
      if (_gameState == GameState.Exploration) {
        Console.CursorVisible = false;
        RenderMap(map);
        RenderPlayer(player.CoordinateX, player.CoordinateY, player.HeroClass);
        player.ShowPlayerInfo();
        MovePlayer(player, map, buildings);
      }
      else {
        Console.ReadKey();
      }
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

  private void TryMove(Player player, Map map, List<Building> buildings, int deltaX, int deltaY) {
    if (map.IsWall(player.CoordinateX + deltaX, player.CoordinateY + deltaY)) {
      return;
    }

    map.FindBuildingAt(player.CoordinateX + deltaX, player.CoordinateY + deltaY, buildings)?.OpenMenu();

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

  public static void ChangeGameState(GameState state) {
    _gameState = state;
  }
}