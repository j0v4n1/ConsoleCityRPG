using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Quests;
using ConsoleCityRPG.Services;
using ConsoleCityRPG.Systems;

namespace ConsoleCityRPG.Entities;

public class Tavern : Building {
  private QuestSystem _questSystem;

  public Tavern(int coordinateX, int coordinateY, QuestSystem questSystem) : base(coordinateX, coordinateY) {
    Name = "Таверна";
    Icon = "🍺";
    _questSystem = questSystem;
  }

  private void OpenMenu(Player player, EventQueue eventQueue) {
    Console.WriteLine($"=== {Name} {Icon}! ===");
    Console.WriteLine();
    Console.WriteLine("1. Взять квест");
    Console.WriteLine("2. Выход");
    var key = Console.ReadLine();
    switch (key) {
      case "1":
        TakeQuest(player);
        eventQueue.Add(new GameEvent(EventType.ChangeState, GameState.Exploration));
        break;
      case "2":
        eventQueue.Add(new GameEvent(EventType.ChangeState, GameState.Exploration));
        break;
    }
  }

  public override void Interact(Player player, EventQueue eventQueue) {
    base.Interact(player, eventQueue);
    OpenMenu(player, eventQueue);
  }

  private void TakeQuest(Player player) {
    var quest = new Quest("Помочь трактирщику", "Трактирщик попросил Вас помочь ему избавить от крыс", false, 50,
      [new QuestObjective("Убить 5 крыс", 0, 5)]);
    _questSystem.AcceptQuest(quest, player);
  }
}