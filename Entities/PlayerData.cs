namespace ConsoleCityRPG.Entities
{
    public abstract class PlayerData
    {
        private static readonly string[] PlayerWalkFrame1 =
        [
            "| o __",
            "T/|)__)",
            " / \\"
        ];

        private static readonly string[] PlayerWalkFrame2 =
        [
            "| o __",
            "T/|)__)",
            "  >\\"
        ];

        private static readonly string[] PlayerWalkFrame3 =
        [
            "| o __",
            "T/|)__)",
            "  |\\"
        ];

        private static readonly string[] PlayerWalkFrame4 =
        [
            "| o __",
            "T/|)__)",
            "  |>"
        ];

        private static readonly string[] PlayerWalkFrame5 =
        [
            "| o __",
            "T/|)__)",
            "  >\\"
        ];

        private static readonly string[] PlayerWalkFrame6 =
        [
            "| o __",
            "T/|)__)",
            "  |\\"
        ];

        public static readonly string[][] PlayerWalkFrames =
        [
            PlayerWalkFrame1, PlayerWalkFrame2,
            PlayerWalkFrame3, PlayerWalkFrame4,
            PlayerWalkFrame5, PlayerWalkFrame6
        ];

        private static readonly string[] PlayerAttackFrame1 =
        [
            "                   ",
            "                   ",
            "                   ",
            "          o __     ",
            "   <----|-|)__)    ",
            "         / \\      "
        ];

        private static readonly string[] PlayerAttackFrame2 =
        [
            "                   ",
            "                   ",
            " <----|-           ",
            "        \\ o __    ",
            "          |)__)    ",
            "         / \\      "
        ];

        private static readonly string[] PlayerAttackFrame3 =
        [
            "                   ",
            "                   ",
            "    <----|-        ",
            "         (o __     ",
            "          |)__)    ",
            "         / \\      "
        ];

        private static readonly string[] PlayerAttackFrame4 =
        [
            "     _______       ",
            "   -         -     ",
            " .              -  ",
            "          o _     .",
            "          \\-|---->",
            "         / \\      "
        ];

        public static readonly string[][] PlayerAttackFrames =
        [
            PlayerAttackFrame1, PlayerAttackFrame2, PlayerAttackFrame3, PlayerAttackFrame4
        ];
    }
}