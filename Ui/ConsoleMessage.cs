using ConsoleCityRPG.Quests;

namespace ConsoleCityRPG.Ui;

public static class ConsoleMessage {
  public static void WelcomeMessage() {
    Console.WriteLine("Welcome to Dungeon Adventure!");
  }

  public static void NameCharacterMessage() {
    Console.WriteLine("Name your character!");
  }

  public static void QuestInfo(Quest quest) {
    Console.SetCursorPosition(40, 0);
    Console.WriteLine("Текущий квест");
    Console.WriteLine(quest.Name);
    Console.WriteLine(quest.Description);
    Console.WriteLine(quest.IsCompleted);
    Console.WriteLine(quest.Objectives);
  }

  public static void PlayerInfoMessage(int gold, int healthPoints, int manaPoints, int attackPower, int defense,
    int coordinateX, int coordinateY) {
    Console.SetCursorPosition(30, 0);
    Console.WriteLine($"💰 {gold}");
    Console.SetCursorPosition(30, 1);
    Console.WriteLine($"❤️ {healthPoints}");
    Console.SetCursorPosition(30, 2);
    Console.WriteLine($"💧 {manaPoints}");
    Console.SetCursorPosition(30, 3);
    Console.WriteLine($"⚔️ {attackPower}");
    Console.SetCursorPosition(30, 4);
    Console.WriteLine($"🛡️ {defense}");
    Console.SetCursorPosition(30, 5);
    if (coordinateX < 10) {
      Console.SetCursorPosition(30, 6);
      Console.WriteLine($"X =   ");
    }

    Console.SetCursorPosition(30, 6);
    Console.WriteLine($"X = {coordinateX}");
    if (coordinateY < 10) {
      Console.SetCursorPosition(30, 7);
      Console.WriteLine($"Y =   ");
    }

    Console.SetCursorPosition(30, 7);
    Console.WriteLine($"Y = {coordinateY}");
  }
}