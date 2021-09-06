using System;
using Blackjack.Entities;
using Blackjack.InputOutput;

namespace Blackjack.BackJackControl
{
    internal class BlackJackEngine
    {
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;
        private Game _game;

        private const int Hit = 1;
        private const int Stay = 0;

        public BlackJackEngine(IInputReader inputReader, IOutputWriter outputWriter)
        {
            _inputReader = inputReader;
            _outputWriter = outputWriter;
        }

        public void ConductGame()
        {
            _game = new Game();
            _game.DrawInitialHand();
            ConductPlayerTurn();
            if (!_game.Player.IsBusted())
                ConductDealerTurn();
            DisplayWinningMessage();
        }

        private void ConductPlayerTurn()
        {
            _outputWriter.PrintPlayerHandStatus(_game.Player);
            int hitOrStay = Hit;
            while (hitOrStay == Hit && _game.Player.Value < 21)
            {
                hitOrStay = GetPlayerResponse();
                if (hitOrStay == Hit)
                {
                    Card newCard = _game.Deck.GetNextCard();
                    _game.AddCardToPlayer(newCard);
                    _outputWriter.PrintText($"You draw {newCard}");
                }

                _outputWriter.PrintPlayerHandStatus(_game.Player);
            }
        }

        private int GetPlayerResponse()
        {
            if (_game.Player.Value >= 21) return Stay;
            _outputWriter.PrintText("\nHit or stay? (Hit = 1, Stay = 0)");
            return _inputReader.GetHitOrStayInput();
        }

        private void ConductDealerTurn()
        {
            _outputWriter.PrintText("\n Dealer's Turn");
            _outputWriter.PrintDealerHandStatus(_game.Dealer);
            while (_game.Dealer.Value <= 17)
            {
                Card newCard = _game.Deck.GetNextCard();
                _game.AddCardToDealer(newCard);
                _outputWriter.PrintText($"Dealer draws {newCard}");
                _outputWriter.PrintDealerHandStatus(_game.Dealer);
            }
        }

        private void DisplayWinningMessage()
        {
            switch (_game.Winner)
            {
                case BlackJackConstants.Winner.Player:
                    _outputWriter.PrintText(BlackJackConstants.PlayerWins);
                    break;
                case BlackJackConstants.Winner.Dealer:
                    _outputWriter.PrintText(BlackJackConstants.DealerWins);
                    break;
                case BlackJackConstants.Winner.Tie:
                    _outputWriter.PrintText(BlackJackConstants.Tied);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}