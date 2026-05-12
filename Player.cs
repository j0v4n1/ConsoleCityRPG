namespace ConsoleCityRPG;

public class Player
{
    private int _healthPoints = 100;
    public int Y { get; private set; } = 1;
    public int X { get; private set; } = 1;

    public void ChangeCoordinates(int newX, int newY)
    {
        X = newX;
        Y = newY;
    }
}