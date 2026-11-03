
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

            bool playerTurnFinished = false;
            while (!playerTurnFinished)
            {
                Console.WriteLine($"\n--- DIN TUR {Player.Name.ToUpper()} ---");
                Console.WriteLine($"Din nuvarande poäng: {Player.Hand.GetValue()}");
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
                    }
                    if (Player.Hand.IsBust()) //kontrollerar om spelaren blir tjock
                    {
                        Console.WriteLine("Dina kort är värda mer än 21 och du blev tjock!");
                        isGameOver = true;
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
            Console.WriteLine($"Dealerns nuvarande poäng: {Dealer.Hand.GetValue()}");
            
            while (Dealer.Hand.GetValue() < 17) // Dealern måste dra kort så länge poängen är under 17
            {
                Card drawnCard = deck.DrawCard();
                Dealer.Hand.AddCard(drawnCard);
                Console.WriteLine($"Dealern drog: {drawnCard.Rank} i {drawnCard.Suit}");
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

        }

    }
}
