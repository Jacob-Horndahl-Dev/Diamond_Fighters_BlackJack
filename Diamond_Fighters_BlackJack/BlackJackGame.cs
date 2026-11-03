
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
