using Blackjack.Entities;
using Blackjack.InputOutput;

namespace Blackjack.BackJackControl
{
    internal class BlackJackEngine
    {
        private readonly IInputReader _inputHandler;
        private readonly IOutputWriter _outputHandler;
        private Deck _deck;
        private Player _player;
        private Player _dealer;
        
        private const int HIT = 1;
        private const int STAY = 0;

        public BlackJackEngine(IInputReader inputHandler, IOutputWriter outputHandler)
        {
            _inputHandler = inputHandler;
            _outputHandler = outputHandler;
        }

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
            _outputHandler.PrintPlayerHandStatus(_player);
            int hitOrStay = HIT;
            while (hitOrStay == HIT && _player.Value < 21)
            {
                hitOrStay = GetPlayerResponse();
                if (hitOrStay == HIT)
                    _player.AddCard(_deck.GetRandomCard());
                _outputHandler.PrintPlayerHandStatus(_player);
            }
        }

        private int GetPlayerResponse()
        {
            if (_player.Value < 21)
            {
                _outputHandler.PrintText("\nHit or stay? (Hit = 1, Stay = 0)");
                return _inputHandler.GetHitOrStayInput();
            }
            return STAY;
        }


        private void ConductDealerTurn()
        {
            _outputHandler.PrintText("\n Dealer's Turn");
            _outputHandler.PrintDealerHandStatus(_dealer);

            while (_dealer.Value <= 17)
            {
                _dealer.AddCard(_deck.GetRandomCard());
                _outputHandler.PrintDealerHandStatus(_dealer);
            }
        }

        private void EndGame()
        {
            string gameOutcome = Scorer.DecideWinner(_player.Value, _dealer.Value);
            _outputHandler.PrintText(gameOutcome);
        }
    }
}