using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;

namespace ConsoleCityRPG.Systems;

public class MonsterSpawner
{
    private readonly List<Position> _freeCells = [];
    private readonly Random _random = new Random();

    public MonsterSpawner(EventQueue eventQueue)
    {
        eventQueue.OnEventAdded += HandleEvent;
    }

    private void HandleEvent(GameEvent gameEvent)
    {
        if (gameEvent.Type == EventType.SpawnMonster)
        {
            for (int i = 0; i < MapData.World.Length; i++)
            {
                for (int j = 0; j < MapData.World[i].Length; j++)
                {
                    if (MapData.World[i][j] == '.')
                    {
                        _freeCells.Add(new Position(i, j));
                    }
                }
            }

            var listLength = _freeCells.Count;
            for (int i = 0; i < _freeCells.Count; i++)
            {
                var randomIndex = _random.Next(0, listLength);
            }
        }
    }
}