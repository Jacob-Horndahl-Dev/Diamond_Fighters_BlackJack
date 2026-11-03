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
            BlackJackGame newGame = new BlackJackGame(); //Skapar ett ny spelrunda
            newGame.GameSetup();

            bool keepPlaying = true;
            while(keepPlaying)
            {                
                newGame.GameRound();
                newGame.Player.RoundsPlayed++;  //Vad heter denna i player?
                if (newGame.Player.Balance <= 0)
                {
                    Console.WriteLine("\nDu har slut på pengar! Ditt saldo är 0 kr och spelet är slut...");
                    Console.WriteLine("Bättre lycka nästa gång!");
                    keepPlaying = false;
                }
                else
                {                    
                    Console.WriteLine($"\nNuvarande saldo: {newGame.Player.Balance} kr"); //När en runda är slut frågar vi om den vill spela en till runda.
                    Console.WriteLine("Vill du spela en runda till? (J/N)");
                    string input = Console.ReadLine().Trim().ToUpper();

                    if (input != "J" && input != "JA" && input != "YES" && input != "Y")
                    {
                        keepPlaying = false;
                        Console.WriteLine("\nÅtervänder till huvudmenyn...");
                    }
                }
            }
            break;

        case "2":
            //kod här
            break;

        case "3":
            Rules.BlackJackRules();
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