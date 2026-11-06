public static class GameDesign
{
    // Visar en rolig design när spelaren vinner.

    
    // Metoden ändrar inte pengar eller poäng, den skriver bara ut text.

    public static void ShowWinDesign()
    {
        // Skriver ut en tom rad för lite extra mellanrum.
        Console.WriteLine();

        // Ritar en ruta med en glad figur och en pokal.
        Console.WriteLine(@"╔══════════════════════╗");
        Console.WriteLine(@"║                      ║      \(^o^)/   🏆");
        Console.WriteLine(@"║     ★ DU VANN! ★     ║        | |");
        Console.WriteLine(@"║                      ║       /   \");
        Console.WriteLine(@"╚══════════════════════╝");

        // Skriver ut ett grattismeddelande under rutan.
        Console.WriteLine();
        Console.WriteLine("       GRATTIS, CHAMP!");
        Console.WriteLine();
    }
        // Visar en gul design när spelaren får Blackjack.
    public static void ShowBlackjackDesign()
    {
        // Sparar bokstäverna som tillsammans bildar ordet BLACKJACK.
        string[] text =
        {
            "████  █     ███   ████ █  █      ███  ███   ████ █  █",
            "█   █ █    █   █ █     █ █         █ █   █ █     █ █ ",
            "████  █    █████ █     ██          █ █████ █     ██  ",
            "█   █ █    █   █ █     █ █      █  █ █   █ █     █ █ ",
            "████  ████ █   █  ████ █  █      ██  █   █  ████ █  █"
        };

        // Gör texten gul.
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();

        // Skapar den övre kanten på rutan.
        string border = "╔" + new string('═', 58) + "╗";
        Console.WriteLine(border);

        // Skriver ut varje rad av texten tillsammans med en glad figur.
        for (int i = 0; i < text.Length; i++)
        {
            string figure = i switch
            {
                0 => @"  \(^o^)/  🏆",
                1 => @"    | |",
                2 => @"    / \",
                _ => ""
            };

            Console.WriteLine("║ " + text[i].PadRight(57) + "║" + figure);
        }

        // Visar vinstmeddelandet under BLACKJACK-texten.
        Console.WriteLine("║" + "★ 21 POÄNG ★  VINST x 2,5 ★".PadLeft(42).PadRight(58) + "║");
        Console.WriteLine("╚" + new string('═', 58) + "╝");
        Console.WriteLine("       ★ JACKPOT, CHAMP! ★");

        // Återställer textfärgen.
        Console.ResetColor();
    }
        // Visar en turkos ruta när det blir oavgjort.
    public static void ShowDrawDesign()
    {
        // Ändrar färgen på texten till turkos.
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Skriver ut en tom rad så designen får lite utrymme.
        Console.WriteLine();

        // Ritar en ruta med text och symboler.
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║             OAVGJORT!                ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║              🤝  🤝                  ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║        INGEN VINNER DENNA GÅNG!      ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        // Återställer färgen så resten av spelet ser normalt ut.
        Console.ResetColor();
    }
        // Visar en röd design när spelaren förlorar.
    public static void ShowLoseDesign()
    {
        // Gör texten röd.
        Console.ForegroundColor = ConsoleColor.Red;

        // Skriver ut en tom rad.
        Console.WriteLine();

        // Ritar en ruta med ett förlustmeddelande.
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║             GAME OVER!               ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║               (╥﹏╥)                 ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║            DU FÖRLORADE!             ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║       BÄTTRE LYCKA NÄSTA GÅNG!       ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        // Återställer textfärgen till det normala.
        Console.ResetColor();
    }
}
