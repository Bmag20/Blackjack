using System;

namespace Blackjack
{
    class BlackJackEngine
    {
        private readonly IInputHandler _inputHandler;
        private readonly IOutputHandler _outputHandler;
        private Deck _deck;
        private Player _player;
        private Player _dealer;
        

        public BlackJackEngine(IInputHandler inputHandler, IOutputHandler outputHandler)
        {
            _inputHandler = inputHandler;
            _outputHandler = outputHandler;
        }

        // Conduct game
        public void ConductGame()
        {
            InitialiseGame();
            int playerValue = ConductPlayerTurn();
            int dealerValue = ConductDealerTurn();
            DecideAndAnnounceWinner(playerValue, dealerValue);
        }

        private void InitialiseGame()
        {
            _player = new Player();
            _dealer = new Player();
            _deck = new Deck();
            _player.AddCard(_deck.GetRandomCard());
            _player.AddCard(_deck.GetRandomCard());
            _dealer.AddCard(_deck.GetRandomCard());
            _dealer.AddCard(_deck.GetRandomCard());
        }

        private int ConductPlayerTurn()
        {
            bool keepPlaying = true;
            int playerValue = Calculator.CalculateSumOfCardValues(_player.CardsInHand);
            Console.WriteLine($"\n You are currently at {playerValue}");
            _outputHandler.PrintCardsInHand(_player.CardsInHand);
            _outputHandler.PrintText("\n Hit or stay? (Hit = 1, Stay = 0)");
            
            while (_inputHandler.GetHitOrStayInput() != 0 && playerValue <= 21)
            {
                _player.AddCard(_deck.GetRandomCard());
                playerValue = Calculator.CalculateSumOfCardValues(_player.CardsInHand);
                _outputHandler.PrintCardsInHand(_player.CardsInHand);
                Console.WriteLine($"\n You are currently at {playerValue}");
                _outputHandler.PrintText("\n Hit or stay? (Hit = 1, Stay = 0)");

            }
            Console.WriteLine($"\n You are currently at {playerValue}");
            _outputHandler.PrintCardsInHand(_player.CardsInHand);
            return playerValue;
        }
        
        private int ConductDealerTurn()
        {
            int sum = Calculator.CalculateSumOfCardValues(_dealer.CardsInHand);
            while (sum <= 17)
            {
                _dealer.AddCard(_deck.GetRandomCard());
                sum = Calculator.CalculateSumOfCardValues(_dealer.CardsInHand);
                _outputHandler.PrintCardsInHand(_dealer.CardsInHand);
                Console.WriteLine(sum);
            }
            return sum;
        }

        private void DecideAndAnnounceWinner(int playerValue, int dealerValue)
        {
            if (playerValue > 21)
            {
                _outputHandler.PrintText("You are currently at Bust!\n");
                //_outputHandler.PrintCardsInHand(player.CardsInHand);
                _outputHandler.PrintText("Dealer wins!! \n");
            }
            else
            {
                if (playerValue == 21)
                {
                    _outputHandler.PrintText(dealerValue == 21
                        ? "You tied with the dealer. No one wins!!"
                        : "You beat the dealer!");
                }
                else if (dealerValue > 21)
                    _outputHandler.PrintText("You beat the dealer!");
                else if ((21 - playerValue) < (21 - dealerValue))
                    _outputHandler.PrintText("You beat the dealer!");
                else
                    _outputHandler.PrintText("\n Dealer wins!! \n");
            }
        }
    }
}