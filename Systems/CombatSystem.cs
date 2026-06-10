using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;

namespace ConsoleCityRPG.Systems;

public class CombatSystem
{
    private Monster? _currentMonster;
    private readonly Player _player;
    private bool _isPlayerTurn = true;

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

    public void Update()
    {
        if (_currentMonster == null) 
        {
            return; 
        }
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("====================");
        Console.WriteLine(_currentMonster.Name);
        Console.WriteLine($"HP: {_currentMonster.Health}");
        Console.WriteLine("Игрок");
        Console.WriteLine($"HP: {_player.Health}");
        Console.WriteLine("1.Атаковать");
        Console.WriteLine("====================");
        Console.ReadKey();
    }
}