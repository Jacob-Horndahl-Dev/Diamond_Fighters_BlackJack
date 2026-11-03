
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
            InitialDeal();
            while (isGameOver == false)
            {
            PlayerTurn();
            }
            while (isGameOver == false)
            {
                DealerTurn();
            }
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

        }

        public void DealerTurn()
        {

        }

        public void GameOutcome()
        {

        }

    }
}
