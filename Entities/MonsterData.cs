namespace ConsoleCityRPG.Entities;

public static class MonsterData
{
    private static readonly string[] MonsterWalkFrame1 =
    [
        "              ",
        " __      ___  ",
        " ' \\, ,/ . ' ",
        "    \" -'     ",
        "              ",
    ];


    private static readonly string[] MonsterWalkFrame2 =
    [
        "              ",
        "\\         /  ",
        " \\__, ,__/.  ",
        "    \" -'     ",
        "              ",
    ];

    private static readonly string[] MonsterWalkFrame3 =
    [
        "              ",
        "              ",
        "    , ,       ",
        "  .'\" -'.    ",
        "  \\     /    ",
    ];

    private static readonly string[] MonsterWalkFrame4 =
    [
        "              ",
        "              ",
        "    , ,       ",
        "   ,\" -\\    ",
        "   |,  |;     ",
    ];

    public static readonly string[][] MonsterIdleFrames =
    [
        MonsterWalkFrame1, MonsterWalkFrame2, MonsterWalkFrame3, MonsterWalkFrame4
    ];
}