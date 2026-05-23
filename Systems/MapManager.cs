using ConsoleCityRPG.Entities;
using ConsoleCityRPG.World;

namespace ConsoleCityRPG.Systems;

public class MapManager(Map currentGameMap, List<Building> currentBuildings) {
  public Map CurrentGameMap { get; private set; } = currentGameMap;

  public List<Building> CurrentBuildings { get; private set; } =
    currentBuildings;

  public void SwitchMap(Map map) {
    CurrentGameMap = map;
  }

  public void SwitchBuildings(List<Building> buildings) {
    CurrentBuildings = buildings;
  }
}