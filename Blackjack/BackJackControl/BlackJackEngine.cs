using Blackjack.Entities;
using Blackjack.InputOutput;

namespace Blackjack.BackJackControl
{
    internal class BlackJackEngine
    {
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;
        private Deck _deck;
        private Hand _player, _dealer;
        
        private const int Hit = 1;
        private const int Stay = 0;

        public BlackJackEngine(IInputReader inputReader, IOutputWriter outputWriter)
        {
            _inputReader = inputReader;
            _outputWriter = outputWriter;
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
            _player = new Hand();
            _dealer = new Hand();
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
            _outputWriter.PrintPlayerHandStatus(_player);
            int hitOrStay = Hit;
            while (hitOrStay == Hit && _player.Value < 21)
            {
                hitOrStay = GetPlayerResponse();
                if (hitOrStay == Hit)
                    AddCardToHand(_deck.GetRandomCard(), _player);
                _outputWriter.PrintPlayerHandStatus(_player);
            }
        }

        private int GetPlayerResponse()
        {
            if (_player.Value >= 21) return Stay;
            _outputWriter.PrintText("\nHit or stay? (Hit = 1, Stay = 0)");
            return _inputReader.GetHitOrStayInput();
        }

        private static void AddCardToHand(Card card, Hand hand)
        {
            hand.AddCard(card);
            Scorer.CalculateValueOfHand(hand);
        }

        private void ConductDealerTurn()
        {
            _outputWriter.PrintText("\n Dealer's Turn");
            _outputWriter.PrintDealerHandStatus(_dealer);

            while (_dealer.Value <= 17)
            {
                AddCardToHand(_deck.GetRandomCard(), _dealer);
                _outputWriter.PrintDealerHandStatus(_dealer);
            }
        }

        private void EndGame()
        {
            string gameOutcome = Scorer.DecideWinner(_player.Value, _dealer.Value);
            _outputWriter.PrintText(gameOutcome);
        }
    }
}