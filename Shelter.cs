namespace ConsoleCityRPG;

public class Shelter : Building
{
    public Shelter(int coordinateX, int coordinateY) : base(coordinateX, coordinateY)
    {
        Role = "Shelter";
    }
}