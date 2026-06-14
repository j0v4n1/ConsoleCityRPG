using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Enum;
using ConsoleCityRPG.Ui;

namespace ConsoleCityRPG.Systems;

public class CombatSystem
{
    private Monster? _currentMonster;
    private readonly Player _player;
    private CombatState _combatState;
    private int _monsterFrame;
    private int _playerIdleFrame;
    private int _playerWalkFrame;
    private int _playerX;
    private readonly EventQueue _eventQueue;
    private readonly RollTheDiceSystem _rollTheDiceSystem;
    private int _playerInitiative;
    private int _monsterInitiative;
    private bool _hasInitiativeOrder;
    private string _combatLog = "";

    public CombatSystem(EventQueue eventQueue, Player player, RollTheDiceSystem rollTheDiceSystem)
    {
        eventQueue.OnEventAdded += HandleEvent;
        _player = player;
        _eventQueue = eventQueue;
        _rollTheDiceSystem = rollTheDiceSystem;
    }

    private void HandleEvent(GameEvent gameEvent)
    {
        if (gameEvent is { Type: EventType.EnterCombat, Payload: Monster monster })
        {
            Console.Clear();
            _currentMonster = monster;
        }
    }

    private void AnimationIdle(AnimationSystem animationSystem)
    {
        animationSystem.DrawFrame(MonsterData.MonsterIdleFrames, _monsterFrame, 30, 0);
        animationSystem.DrawFrame(PlayerData.PlayerIdleFrames, _playerIdleFrame, 0, 0);

        _playerIdleFrame++;
        _monsterFrame++;

        if (_playerIdleFrame >= PlayerData.PlayerIdleFrames.Length)
        {
            _playerIdleFrame = 0;
        }

        if (_monsterFrame >= MonsterData.MonsterIdleFrames.Length)
        {
            _monsterFrame = 0;
        }
    }

    private void AnimationWalk(AnimationSystem animationSystem)
    {
        animationSystem.DrawFrame(PlayerData.PlayerWalkFrames, _playerWalkFrame, _playerX, 0);
        _playerWalkFrame++;
        if (_playerWalkFrame >= PlayerData.PlayerWalkFrames.Length)
        {
            _playerWalkFrame = 0;
        }

        _playerX++;
    }

    private void DetermineInitiativeOrder()
    {
        if (!_hasInitiativeOrder)
        {
            _playerInitiative = _rollTheDiceSystem.Roll(RollType.Initiative, 0, 0,
                _player.Initiative);
            _monsterInitiative = _rollTheDiceSystem.Roll(RollType.Initiative, 0, 0,
                _currentMonster!.Initiative);
            _hasInitiativeOrder = true;

            _combatState = _monsterInitiative < _playerInitiative ? CombatState.PlayerTurn : CombatState.EnemyTurn;
        }
    }

    private bool IsAttackPass(int attackPower, int defense)
    {
        var i = _rollTheDiceSystem.Roll(RollType.HitChance, 0, attackPower);
        return i >= defense;
    }

    public void Update(AnimationSystem animationSystem)
    {
        if (_currentMonster == null)
        {
            return;
        }

        DetermineInitiativeOrder();

        AnimationIdle(animationSystem);

        ConsoleMessage.CombatInfo(_currentMonster.Name, _currentMonster.Health, _player.Health, _combatLog,
            _combatState.ToString());

        switch (_combatState)
        {
            case CombatState.PlayerTurn:
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            _combatState = CombatState.PlayerWalkToEnemy;
                            break;
                        case ConsoleKey.D2:
                            _eventQueue.Add(new GameEvent(EventType.ChangeState, GameState.Exploration));
                            break;
                    }
                }

                break;

            case CombatState.PlayerWalkToEnemy:
                AnimationWalk(animationSystem);
                if (_playerX >= 30)
                {
                    _combatState = CombatState.PlayerAttack;
                }

                break;

            case CombatState.PlayerAttack:
                // анимация удара
                if (IsAttackPass(_player.AttackPower, _currentMonster.Defense))
                {
                    _currentMonster.OnAttacked(_player.AttackPower);
                }

                if (_currentMonster.Health <= 0)
                {
                    _eventQueue.Add(new GameEvent(EventType.ChangeState, GameState.Exploration));
                }

                _combatState = CombatState.PlayerWalkBack;
                break;

            case CombatState.PlayerWalkBack:
                // анимация отхода от врага
                _combatState = CombatState.EnemyTurn;
                break;

            case CombatState.EnemyTurn:
                _combatState = CombatState.EnemyWalkToPlayer;
                break;
            case CombatState.EnemyWalkToPlayer:
                // анимация подхода к игроку
                _combatState = CombatState.EnemyAttack;
                break;
            case CombatState.EnemyAttack:
                // анимация атаки 
                if (IsAttackPass(_currentMonster.AttackPower, _player.Defense))
                {
                    _player.OnAttacked(_currentMonster.AttackPower);
                }
                else
                {
                    _combatLog = "Монстр промахнулся";
                }

                _combatState = CombatState.EnemyWalkBack;
                break;
            case CombatState.EnemyWalkBack:
                // анимация отхода от игрока
                _combatState = CombatState.PlayerTurn;
                break;
        }
    }
}
// Нужно раскидать анимацию по кейсам чтобы анимация стояния не наслаивалась на ходьбу!