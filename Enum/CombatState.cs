namespace ConsoleCityRPG.Enum;

public enum CombatState
{
    PlayerTurn,
    PlayerWalkToEnemy,
    PlayerAttack,
    PlayerWalkBack,

    EnemyTurn,
    EnemyWalkToPlayer,
    EnemyAttack,
    EnemyWalkBack,

    Victory,
    Defeat
}