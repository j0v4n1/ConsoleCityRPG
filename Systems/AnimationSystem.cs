using ConsoleCityRPG.Entities;

namespace ConsoleCityRPG.Systems;

public class AnimationSystem
{
    public void AnimationWalk(string[][] entity, int speedAnimation)
    {
        int i = 0;
        while (true)
        {
            Console.SetCursorPosition(0, 0);

            foreach (var line in entity[i])
            {
                Console.WriteLine(line);
            }

            i++;

            if (i >= entity.Length)
                i = 0;

            Thread.Sleep(speedAnimation);
        }
    }

    public void AnimationAttack()
    {
        int i = 0;
        while (true)
        {
            Console.SetCursorPosition(0, 0);

            foreach (var line in PlayerData.PlayerAttackFrames[i])
            {
                Console.WriteLine(line);
            }

            i++;

            if (i >= PlayerData.PlayerAttackFrames.Length)
                i = 0;

            Thread.Sleep(250);
        }
    }
}