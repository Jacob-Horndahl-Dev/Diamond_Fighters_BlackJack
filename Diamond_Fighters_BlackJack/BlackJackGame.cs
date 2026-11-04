
namespace Diamond_Fighters_BlackJack
{
    internal class BlackJackGame
    {
        //public int GameNo { get; private set; } //håller koll på spel id
        //public static List<BlackJackGame> GameHistory { get; private set; } = []; //Denna kanske ska vara i high-score klassen?
        public Player Player { get; private set; } = new Player(); //Kan också vara en lista om det skulle behövas
        public Dealer Dealer { get; private set; } = new Dealer(); //byt namn om dealer klassen heter något annat sen
        private Deck deck  = new Deck();
        private bool isGameOver = false;

    /*public BlackJackGame()
            {
            GameNo = BlackJackGame.GameHistory.Count + 1;
            GameHistory.Add(this);

            }*/
        public void GameSetup()
        {
            Console.WriteLine("Nytt spel");

            string inputPlayerName = "";
            while(string.IsNullOrWhiteSpace(inputPlayerName))
            {
                Console.WriteLine("Under vilket namn vill du spela som?");
                inputPlayerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputPlayerName))
                {
                    Console.WriteLine("Namnet får inte vara tomt, försök igen:");
                }
            }
            Player.Name = inputPlayerName;
        }

        public void GameRound()
        {
            PlayerBet();
            if (isGameOver) return;
            
            InitialDeal();
            
            PlayerTurn();
            
            DealerTurn();

            GameOutcome();

            deck.PrepareNextRound();
        }

        public void PlayerBet()
        {
            int playerBetAmount = 0;
            if (Player.Balance > 0)
            {
                Console.WriteLine($"Du har {Player.Balance} kr att spela med. Hur mycket vill du satsa?");
                while (!int.TryParse(Console.ReadLine(), out playerBetAmount) || playerBetAmount < 1 || playerBetAmount > Player.Balance)
                {
                        Console.WriteLine($"Du måste ange en giltig summa att satsa, minst 1 kr och max {Player.Balance} kr!");
                }

                Player.Bet = playerBetAmount;
                Player.Balance = Player.Balance - playerBetAmount;
            }
            else isGameOver = true;
        }

        public void InitialDeal()
        {
            Console.WriteLine("Delar ut första kortet till spelaren:");
            Card playerCard1 = deck.DrawCard();
            Player.Hand.AddCard(playerCard1);
            Console.WriteLine($"Du fick: {playerCard1.Rank} i {playerCard1.Suit}");

            Console.WriteLine("Delar ut första kortet till dealern:");
            Card dealerCard1 = deck.DrawCard();
            Dealer.Hand.AddCard(dealerCard1);
            Console.WriteLine($"Dealern fick: {dealerCard1.Rank} i {dealerCard1.Suit}");

            Console.WriteLine("Delar ut spelarens andra kort:");
            Card playerCard2 = deck.DrawCard();
            Player.Hand.AddCard(playerCard2);
            Console.WriteLine($"Du fick: {playerCard2.Rank} i {playerCard2.Suit}");
            Console.WriteLine($"Din nuvarande poäng: {Player.Hand.GetValue()}");

            if (Player.Hand.IsBlackjack()) //kontrollerar om spelaren får blackjack direkt
            {
                Console.WriteLine("Du fick BLACKJACK!");
                isGameOver = true;             
            }

            Console.WriteLine("Delar ut dealerns dolda kort:");
            Card dealerCard2 = deck.DrawCard();
            Dealer.Hand.AddCard(dealerCard2);
            Console.WriteLine($"Dealern fick ett dolt kort");
            
            if (Dealer.Hand.IsBlackjack()) //kontrollerar om dealern får blackjack
            {
                Console.WriteLine("Dealern fick BLACKJACK!");
                isGameOver = true;
            }
        }

        public void PlayerTurn()
        {
            if (isGameOver == true) return;

            List<Card> dealerCards = Dealer.Hand.GetCards(); //för att kunna visa vad dealerns uppvända kort är
            bool playerTurnFinished = false;
            while (!playerTurnFinished)
            {
                Console.WriteLine($"\n--- DIN TUR {Player.Name.ToUpper()} ---");
                Console.WriteLine("Dina kort:");                                        //Lägg in metoden för att visa vad spelaren har på handen här
                Console.WriteLine($"Dina kort är värda: {Player.Hand.GetValue()}");
                Console.WriteLine("");
                Console.WriteLine($"Dealern har: {dealerCards[0].Rank} i {dealerCards[0].Suit} och ett dolt kort");
                Console.WriteLine($"Dealerns första kort är värt: {dealerCards[0].Value}");
                Console.WriteLine("");
                Console.WriteLine("Vill du ta ett till kort (HIT) eller stanna (STAND)?");
                Console.WriteLine("Välj H eller S:");
                string hitStandInput = Console.ReadLine().Trim().ToUpper();

                if (hitStandInput == "H") //Om spelaren vill dra ett till kort
                {
                    Card drawnCard = deck.DrawCard();
                    Player.Hand.AddCard(drawnCard);
                    Console.WriteLine($"Du drog: {drawnCard.Rank} i {drawnCard.Suit}");
                    Console.WriteLine($"Din nuvarande poäng: {Player.Hand.GetValue()}");

                    if (Player.Hand.IsBlackjack()) //kontrollerar om spelaren får blackjack
                    {
                        Console.WriteLine("Du fick BLACKJACK!");
                        isGameOver = true;
                        playerTurnFinished = true;
                    }
                    if (Player.Hand.IsBust()) //kontrollerar om spelaren blir tjock
                    {
                        Console.WriteLine("Dina kort är värda mer än 21 och du blev tjock!");
                        isGameOver = true;
                        playerTurnFinished = true;
                    }
                }
                else if (hitStandInput == "S") //Om spelaren väljer att stanna
                {
                    Console.WriteLine("Du stannar.");
                    Console.WriteLine($"Din nuvarande poäng: {Player.Hand.GetValue()}");
                    playerTurnFinished = true;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val! Skriv 'H' för Hit eller 'S' för Stand.");
                }

            }
        }

        public void DealerTurn()
        {
            if (isGameOver == true) return;

            Console.WriteLine($"\n--- DEALERNS TUR ---");
            Console.WriteLine("Dealerns första kort och dolda kort som vänds upp är:");       //Här kan vi skriva ut dealerns kort på hand
            Console.WriteLine($"Dealerns nuvarande poäng: {Dealer.Hand.GetValue()}");
            
            while (Dealer.Hand.GetValue() < 17) // Dealern måste dra kort så länge poängen är under 17
            {
                Card drawnCard = deck.DrawCard();
                Dealer.Hand.AddCard(drawnCard);
                Console.WriteLine($"Dealern drog: {drawnCard.Rank} i {drawnCard.Suit}");
                Console.WriteLine("Dealern har nu:");                   //Här kan vi skriva in vilka kort dealern har på hand
                Console.WriteLine($"Dealerns nya poäng: {Dealer.Hand.GetValue()}");
            }
            
            if (Dealer.Hand.IsBust()) // Kolla om dealern blev tjock
            {
                Console.WriteLine("Dealern blev tjock (över 21)!");
            }
            else
            {
                Console.WriteLine($"Dealern stannar på {Dealer.Hand.GetValue()} poäng.");
            }
        }

        public void GameOutcome()
        {
            Console.WriteLine("\n--- BLACKJACK SPELET ÄR ÖVER ---");
            Console.WriteLine("");

            int playerScore = Player.Hand.GetValue();
            int dealerScore = Dealer.Hand.GetValue();

            Console.WriteLine($"{Player.Name} poäng: {playerScore}");
            Console.WriteLine($"Dealerns poäng: {dealerScore}");

            // 1. Kolla om spelaren blev tjock (förlorar direkt)
            if (Player.Hand.IsBust())
            {
                Console.WriteLine("Du förlorade eftersom du gick över 21.");
            }
            // 2. Kolla om dealern blev tjock (spelaren vinner)
            else if (Dealer.Hand.IsBust())
            {
                Console.WriteLine("Grattis! Dealern blev tjock – du vinner!");
                Player.Balance += Player.Bet * 2;
            }
            // 3. Kolla om spelaren har Blackjack (och dealern inte har det)
            else if (Player.Hand.IsBlackjack() && !Dealer.Hand.IsBlackjack())
            {
                Console.WriteLine("BLACKJACK! Du vinner extra mycket!");
                Player.Balance += (int)(Player.Bet * 2.5); //(int) gör att vinsten rundas neråt utan att krascha!
            }
            // 4. Jämför poäng om ingen har blivit tjock
            else if (playerScore > dealerScore)
            {
                Console.WriteLine("Grattis, du vinner med högre poäng!");
                Player.Balance += Player.Bet * 2;
            }
            else if (playerScore < dealerScore)
            {
                Console.WriteLine("Dealern vinner med högre poäng. Bättre lycka nästa gång!");                
            }
            else
            {
                Console.WriteLine("Oavgjort (Push)! Insatsen går tillbaka.");
                Player.Balance += Player.Bet;
            }
            // Nollställer händerna inför nästa runda
            Player.Hand.Clear();
            Dealer.Hand.Clear();
            isGameOver = false; //sätter false så nästa runda kan börja
        }

    }
}
