using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Systems;
using ConsoleCityRPG.Ui;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Core;

public class Game
{
    private bool _isRunning = true;

    public void Run()
    {
        var eventQueue = new EventQueue();
        var gameStateManager = new GameStateManager(eventQueue);
        var player = new Player();
        new QuestSystem(player, eventQueue);
        var cityMap = new Map(MapData.City);
        var worldMap = new Map(MapData.World);
        var tavern = new Tavern(16, 2);
        var shop = new Shop(6, 4);
        var shelter = new Shelter(14, 5);
        var cityPortal = new Portal(19, 7, worldMap, 0, 1);
        var worldPortal = new Portal(0, 1, cityMap, 19, 7);
        var movement = new MovementSystem(eventQueue);
        var renderer = new Renderer();
        var inputController = new InputController();
        var explorationSystem = new ExplorationSystem();
        List<Building> cityBuildings = [tavern, shop, shelter, cityPortal];
        List<Building> worldBuildings = [worldPortal];
        cityMap.SetBuildings(cityBuildings);
        worldMap.SetBuildings(worldBuildings);
        var mapManager = new MapManager(cityMap, cityBuildings, eventQueue);
        new MonsterSpawner(eventQueue, mapManager, MapData.World);
        var buildingSystem = new BuildingSystem(eventQueue);
        var rollTheDiceSystem = new RollTheDiceSystem();
        var combatSystem = new CombatSystem(eventQueue, player, rollTheDiceSystem);
        var animationSystem = new AnimationSystem();
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        // foreach (var str in MonsterData.MonsterWalkFrame4)
        // {
        //     Console.WriteLine(str);
        // }
        while (_isRunning)
        {
            Console.CursorVisible = false;
            if (gameStateManager.GameState != GameState.Combat)
            {
                player.ShowPlayerInfo();
                player.ShowQuestInfo();
            }

            Console.SetCursorPosition(40, 10);
            // Console.WriteLine(gameStateManager.GameState);
            switch (gameStateManager.GameState)
            {
                case GameState.Exploration:
                    explorationSystem.Update(renderer, mapManager, player,
                        inputController, movement);
                    break;
                case GameState.InBuilding:
                    buildingSystem.Update(eventQueue);
                    break;
                case GameState.Combat:
                    Console.Clear();
                    combatSystem.Update(animationSystem);
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}