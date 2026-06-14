using ConsoleCityRPG.Quests;
using ConsoleCityRPG.Ui;

namespace ConsoleCityRPG.Entities;

public class Player
{
    public const char HeroIcon = '@';
    public int CoordinateY { get; private set; } = 1;
    public int CoordinateX { get; private set; } = 1;
    public int Health { get; private set; } = 100;
    public int ManaPoints { get; private set; } = 100;
    public int Gold { get; private set; } = 100;
    public int AttackPower { get; private set; } = 5;
    public int Defense { get; private set; } = 12;
    public int Initiative { get; private set; } = 5;
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
        ConsoleMessage.PlayerInfoMessage(Gold, Health, ManaPoints,
            AttackPower, Defense, CoordinateX, CoordinateY);
    }

    public void AddQuest(Quest quest)
    {
        Quests.Add(quest);
    }

    public void OnAttacked(int attackPower)
    {
        Health -= attackPower;
    }
}