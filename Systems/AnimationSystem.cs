namespace ConsoleCityRPG.Systems;

public class AnimationSystem
{
    public void DrawFrames(string[][] frames, int frameIndex, int framePositionX, int framePositionY)
    {
        int i = 0;
        foreach (var frame in frames[frameIndex])
        {
            Console.SetCursorPosition(framePositionX, framePositionY + i);
            Console.WriteLine(frame);
            i++;
        }
    }
}