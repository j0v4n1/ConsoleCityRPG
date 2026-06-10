using ConsoleCityRPG.Quests;
using ConsoleCityRPG.Ui;

namespace ConsoleCityRPG.Entities;

public class Player
{
    public const char HeroIcon = '@';
    public int CoordinateY { get; private set; } = 1;
    public int CoordinateX { get; private set; } = 1;
    public int Health { get; private set; } = 100;
    private int _manaPoints = 100;
    private int _gold = 100;
    private int _attackPower = 5;
    private int _defense = 5;
    private List<Quest> Quests { get; set; } = [];

    public void ChangeCoordinates(int newX, int newY)
    {
        CoordinateX = newX;
        CoordinateY = newY;
    }

    public void ShowQuestInfo()
    {
        foreach (var quest in Quests)
        {
            ConsoleMessage.QuestInfo(quest);
        }
    }

    public void ShowPlayerInfo()
    {
        ConsoleMessage.PlayerInfoMessage(_gold, Health, _manaPoints,
            _attackPower, _defense, CoordinateX, CoordinateY);
    }

    public void AddQuest(Quest quest)
    {
        Quests.Add(quest);
    }
}