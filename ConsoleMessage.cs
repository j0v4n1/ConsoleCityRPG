namespace ConsoleCityRPG;

public static class ConsoleMessage {
  public static void WellcomeMessage() {
    Console.WriteLine("Wellcome to Dungeon Adventure!");
  }

  public static void NameCharacterMessage() {
    Console.WriteLine("Name your character!");
  }

  public static void ChooseClassCharacterMessage() {
    Console.WriteLine("Choose your class!");
    Console.WriteLine();
    Console.WriteLine("1.Warrior 🧝");
    Console.WriteLine("2.Mage 🧙‍");
    Console.WriteLine("3.Thief 🥷");
  }
}