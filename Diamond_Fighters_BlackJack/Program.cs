using Diamond_Fighters_BlackJack;

Console.WriteLine("D I A M O N D  F I G H T E R S  B L A C K J A C K");
Console.WriteLine("");

bool run = true;
while (run)
{
    Console.WriteLine("== Meny ==");
    Console.WriteLine("[1] Starta nytt spel");
    Console.WriteLine("[2] Visa topplista");
    Console.WriteLine("[3] Visa regler");
    Console.WriteLine("[4] Avsluta");

    Console.WriteLine("Välj [1]-[4]:");
    string menuChoice = Console.ReadLine();
    switch (menuChoice)
    {
        case "1":
            //kod här
            break;

        case "2":
            //kod här
            break;

        case "3":
            //kod här
            break;

        case "4":
            Console.WriteLine("Avslutar programmet...");
            run = false;
            break;

        default:
            Console.WriteLine("\nOgiltigt menyval. Försök igen!");
            Console.WriteLine("");
            break;
    }
}