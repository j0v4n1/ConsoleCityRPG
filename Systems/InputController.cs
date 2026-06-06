namespace ConsoleCityRPG.Systems;

public class InputController
{
    public ConsoleKeyInfo GetKey()
    {
        var key = Console.ReadKey(true);
        return key;
    }
}