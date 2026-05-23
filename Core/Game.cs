using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Services;
using ConsoleCityRPG.Systems;
using ConsoleCityRPG.Ui;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Core;

public class Game {
  private bool _isRunning = true;
  private static GameState _gameState = GameState.Exploration;

  public void Run() {
    var eventQueue = new EventQueue();
    var questSystem = new QuestSystem();
    var player = new Player();
    var cityMap = new Map(MapData.City);
    var worldMap = new Map(MapData.World);
    var tavern = new Tavern(16, 2, questSystem);
    var shop = new Shop(6, 4);
    var shelter = new Shelter(14, 5);
    var cityPortal = new Portal(19, 7, worldMap, 0, 1);
    var worldPortal = new Portal(0, 1, cityMap, 19, 7);
    var movement = new MovementSystem(eventQueue);
    var renderer = new Renderer();
    var inputController = new InputController();
    List<Building> cityBuildings = [tavern, shop, shelter, cityPortal];
    List<Building> worldBuildings = [worldPortal];
    var mapManager = new MapManager(cityMap, cityBuildings);

    Console.Clear();
    Console.SetCursorPosition(0, 0);
    while (_isRunning) {
      Console.CursorVisible = false;
      player.ShowPlayerInfo();
      player.ShowQuestInfo();
      switch (_gameState) {
        case GameState.Exploration:
          renderer.Render(mapManager.CurrentGameMap, mapManager, player);
          var input = inputController.GetKey();
          movement.Update(player, mapManager.CurrentGameMap,
            mapManager.CurrentBuildings, input);
          break;
        case GameState.InBuilding:
          break;
      }

      foreach (var e in eventQueue.GetAll()) {
        switch (e.Type) {
          case EventType.SwitchWorld:
            if (e.Payload != null) {
              mapManager.SwitchMap((Map)e.Payload);
            }

            break;
          case EventType.ChangeState:
            if (e.Payload != null) {
              _gameState = (GameState)e.Payload;
            }

            break;
        }
      }

      eventQueue.Clear();
    }
  }
}