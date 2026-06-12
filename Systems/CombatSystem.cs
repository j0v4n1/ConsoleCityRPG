using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;

namespace ConsoleCityRPG.Systems;

public class CombatSystem
{
    private Monster? _currentMonster;

    private readonly Player _player;

    // private bool _isPlayerTurn = true;
    private int _monsterFrame;
    private int _playerFrame;

    public CombatSystem(EventQueue eventQueue, Player player)
    {
        eventQueue.OnEventAdded += HandleEvent;
        _player = player;
    }

    private void HandleEvent(GameEvent gameEvent)
    {
        if (gameEvent is { Type: EventType.EnterCombat, Payload: Monster monster })
        {
            Console.Clear();
            _currentMonster = monster;
        }
    }

    public void Update(AnimationSystem animationSystem)
    {
        if (_currentMonster == null)
        {
            return;
        }

        animationSystem.DrawFrames(MonsterData.MonsterIdleFrames, _monsterFrame, 30, 0);
        animationSystem.DrawFrames(PlayerData.PlayerIdleFrames, _playerFrame, 0, 0);

        _playerFrame++;
        _monsterFrame++;

        if (_playerFrame >= PlayerData.PlayerIdleFrames.Length)
        {
            _playerFrame = 0;
        }

        if (_monsterFrame >= MonsterData.MonsterIdleFrames.Length)
        {
            _monsterFrame = 0;
        }

        Console.WriteLine("====================");
        Console.WriteLine(_currentMonster.Name);
        Console.WriteLine($"HP: {_currentMonster.Health}");
        Console.WriteLine();
        Console.WriteLine("Игрок");
        Console.WriteLine($"HP: {_player.Health}");
        Console.WriteLine();
        Console.WriteLine("1.Атаковать");
        Console.WriteLine("2.Побег");
        Console.WriteLine("====================");
        if (Console.KeyAvailable)
        {
            var consoleKeyInfo = Console.ReadKey(true);

            // switch (consoleKeyInfo.Key)
            // {
            //     case "1":
            //         break;
            // }
        }
    }
}