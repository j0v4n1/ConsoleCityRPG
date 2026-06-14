namespace ConsoleCityRPG.Entities;

public class Animation(string[][] frames)
{
    public string[][] Frames { get; set; } = frames;
    public int CurrentFrame { get; private set; }

    public void Update()
    {
        CurrentFrame++;
    }
}