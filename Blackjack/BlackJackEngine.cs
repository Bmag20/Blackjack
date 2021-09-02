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
            ConductPlayerTurn();
            if (!_player.IsBusted())
                ConductDealerTurn();
            EndGame();
        }

        private void InitialiseGame()
        {
            _player = new Player();
            _dealer = new Player();
            _deck = new Deck();
            DrawInitialHand();
        }

        private void DrawInitialHand()
        {
            _player.AddCard(_deck.GetRandomCard());
            _player.AddCard(_deck.GetRandomCard());
            _dealer.AddCard(_deck.GetRandomCard());
            _dealer.AddCard(_deck.GetRandomCard());
        }


        private void ConductPlayerTurn()
        {
            _outputHandler.PrintHandStatus(_player);
            if (_player.Value >= 21)
                return;
            _outputHandler.PrintText("\n Hit or stay? (Hit = 1, Stay = 0)");
            while (_inputHandler.GetHitOrStayInput() != 0 && !_player.IsBusted())
            {
                _player.AddCard(_deck.GetRandomCard());
                _outputHandler.PrintHandStatus(_player);
                if (!_player.IsBusted())
                    _outputHandler.PrintText("\n Hit or stay? (Hit = 1, Stay = 0)");
                else
                {
                    _outputHandler.PrintText("You are at Bust!!");
                    return;
                }
            }
        }

        private void ConductDealerTurn()
        {
            _outputHandler.PrintHandStatus(_dealer);

            while (_dealer.Value <= 17)
            {
                _dealer.AddCard(_deck.GetRandomCard());
                _outputHandler.PrintHandStatus(_dealer);
            }
        }

        private void EndGame()
        {
            string winner = Calculator.DecideWinner(_player.Value, _dealer.Value);
            _outputHandler.PrintText($"{winner} wins!!");
        }
    }
}