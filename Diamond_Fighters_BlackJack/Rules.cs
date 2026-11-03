namespace Diamond_Fighters_BlackJack
{
    internal class Rules
    {
        public static void BlackJackRules()
        {
            Console.Clear();
            Console.WriteLine("== D I A M O N D  F I G H T E R S  B L A C K J A C K ==");
            Console.WriteLine("");            
            Console.WriteLine("BlackJack är ett kortspel där du spelar mot dealern.");
            Console.WriteLine("Målet är att med korten man drar hamnar närmare 21 än dealern, men du får absolut inte gå över 21!");
            Console.WriteLine("Går du eller dealern över 21 blir ni \"tjock\" och förlorar omedelbart." );
            Console.WriteLine("");
            Console.WriteLine("Korten består av en vanlig kortlek med 52 kort.");
            Console.WriteLine("Färgerna spelar ingen roll och de numrerade korten 2-10 är värda sin siffra.");
            Console.WriteLine("Klädda kort (knekt, dam och kung) är värda 10.");
            Console.WriteLine("Ess är värda 1 eller 11, det som är bäst för handen.");
            Console.WriteLine("");

            Console.WriteLine("En spelrunda går till så här:");
            Console.WriteLine("");
            Console.WriteLine("1. Spelaren lägger en insats.");
            Console.WriteLine("");
            Console.WriteLine("2. Spelaren och dealern får två kort var. Spelarens kort är uppvända. Dealern har ett uppvänt och ett dolt kort.");
            Console.WriteLine("");
            Console.WriteLine("3. Man kan få Blackjack på första draget, och det betyder att man dragit ett ess och ett kort värt 10 som de två första korten.");
            Console.WriteLine("   Har någon blackjack avgörs rundan direkt.");
            Console.WriteLine("   Har båda Blackjack blir det oavgjort och man får tillbaka sin insats.");
            Console.WriteLine("   Om endast spelaren får blackjack vinner spelaren en bonusvinst motsvarande 2,5 gånger insatsen.");
            Console.WriteLine("   Eventuella decimaler avrundas nedåt till närmaste hela belopp. Har bara dealern blackjack förlorar spelaren sin insats.");
            Console.WriteLine("");
            Console.WriteLine("4. Om det inte någon får blackjack på starthanden kan spelaren välja om hen vill dra ett till kort eller stanna.");
            Console.WriteLine("   Detta upprepas tills spelaren stannar, når 21 eller går över 21. Går spelaren över 21 förlorar denne direkt.");
            Console.WriteLine("");
            Console.WriteLine("5. Dealern vänder sedan upp sitt dolda kort och drar kort tills summan är minst 17. Då stannar dealern. Går dealern över 21 vinner spelaren.");
            Console.WriteLine("");
            Console.WriteLine("6. Handen närmast 21 vinner. Vid vinst får spelaren tillbaka sin insats gånger 2.");
            Console.WriteLine("   Är det lika blir det oavgjort och insatsen går tillbaka. Vinner dealern förlorar spelaren sin insats.");
            Console.WriteLine("");
            Console.WriteLine("   I denna version an blackjack kan man inte dubbla, dela eller försäkra sig.");

            Console.WriteLine("");

            Console.WriteLine("Good luck! And may the odds _ever_ be in your favor!");
            Console.WriteLine("");
            Console.WriteLine("Tryck för att fortsätta...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
