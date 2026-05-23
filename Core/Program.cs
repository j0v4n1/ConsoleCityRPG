using System.Text;

namespace ConsoleCityRPG.Core;

internal static class Program {
  private static void Main(string[] args) {
    Console.OutputEncoding = Encoding.UTF8;
    Game game = new();
    game.Run();
  }
}