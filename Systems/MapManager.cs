using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Systems;

public class MapManager
{
    public Map CurrentGameMap { get; private set; }
    public List<Building> CurrentBuildings { get; private set; }
    public List<Monster> Monsters { get; set; } = [];

    public MapManager(Map currentGameMap, List<Building> currentBuildings,
        EventQueue eventQueue)
    {
        CurrentGameMap = currentGameMap;
        CurrentBuildings = currentBuildings;
        eventQueue.OnEventAdded += HandleEvent;
    }

    private void SwitchMap(Map map)
    {
        CurrentGameMap = map;
    }

    private void SwitchBuildings(List<Building> buildings)
    {
        CurrentBuildings = buildings;
    }

    private void HandleEvent(GameEvent gameEvent)
    {
        if (gameEvent.Type == EventType.SwitchWorld)
        {
            var map = (Map?)gameEvent.Payload;
            if (map != null)
            {
                SwitchMap(map);
                SwitchBuildings(map.Buildings);
            }
        }
    }
}