using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;

namespace ConsoleCityRPG.Systems;

public class MonsterSpawner
{
    private readonly List<Position> _freeCells = [];
    private readonly Random _random = new();
    private readonly MapManager _mapManager;
    private readonly string[] _mapData;

    public MonsterSpawner(EventQueue eventQueue, MapManager mapManager, string[] mapData)
    {
        eventQueue.OnEventAdded += HandleEvent;
        _mapManager = mapManager;
        _mapData = mapData;
    }

    private void CreateFreeCellsList()
    {
        _freeCells.Clear();
        for (int i = 0; i < _mapData.Length; i++)
        {
            for (int j = 0; j < _mapData[i].Length; j++)
            {
                if (_mapData[i][j] == '.')
                {
                    _freeCells.Add(new Position(j, i));
                }
            }
        }
    }

    private void HandleEvent(GameEvent gameEvent)
    {
        if (gameEvent.Type != EventType.SpawnMonster) return;
        CreateFreeCellsList();

        for (int i = 0; i < 5; i++)
        {
            int listLength = _freeCells.Count;
            int randomIndex = _random.Next(0, listLength);
            var monsterName = gameEvent.Payload as string ?? "Монстр";
            var monster = new Monster(_freeCells[randomIndex], monsterName);
            _mapManager.Monsters.Add(monster);
            _freeCells.RemoveAt(randomIndex);
        }
    }
}