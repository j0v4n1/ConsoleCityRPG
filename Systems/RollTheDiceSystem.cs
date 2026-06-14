using ConsoleCityRPG.Enum;

namespace ConsoleCityRPG.Systems;

public class RollTheDiceSystem
{
    private readonly Random _random = new();

    public int Roll(RollType rollType,
        int defence = 0,
        int attackPower = 0,
        int initiative = 0)
    {
        var random = _random.Next(1, 21);
        switch (rollType)
        {
            case RollType.Initiative:

                if (random == 20)
                {
                    random = 100;
                }

                if (random == 1)
                {
                    random = -100;
                }

                return random + initiative;

            case RollType.HitChance:

                if (random == 20)
                {
                    random = attackPower * 2;
                }

                if (random == 1)
                {
                    random = -attackPower;
                }

                return random + attackPower;
        }

        return random;
    }
}