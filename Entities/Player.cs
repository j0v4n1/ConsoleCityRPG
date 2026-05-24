using ConsoleCityRPG.Quests;
using ConsoleCityRPG.Ui;
namespace ConsoleCityRPG.Entities;
public class Player {
  public char HeroClass { get; } = '@';
  public int CoordinateY { get; private set; } = 1;
  public int CoordinateX { get; private set; } = 1;
  private int _healthPoints = 100;
  private int _manaPoints = 100;
  private int _gold = 100;
  private int _attackPower = 5;
  private int _defense = 5;
  private List<Quest> Quests { get; set; } = [];
  public void ChangeCoordinates(int newX, int newY) {
    CoordinateX = newX;
    CoordinateY = newY;
  }
  public void ShowQuestInfo() {
    foreach (var quest in Quests) {
      ConsoleMessage.QuestInfo(quest);
    }
  }
  public void ShowPlayerInfo() {
    Ui.ConsoleMessage.PlayerInfoMessage(_gold, _healthPoints, _manaPoints,
      _attackPower, _defense, CoordinateX, CoordinateY);
  }
  public void AddQuest(Quest quest) {
    Quests.Add(quest);
  }
}