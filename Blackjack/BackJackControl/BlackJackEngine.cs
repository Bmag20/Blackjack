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
            if (_game.PlayerValue < 21)
                ConductDealerTurn();
            DisplayWinningMessage();
        }

        private void ConductPlayerTurn()
        {
            int hitOrStay = Hit;
            while (hitOrStay == Hit && _game.PlayerValue < 21)
            {
                PrintPlayerHandStatus();
                hitOrStay = GetPlayerResponse();
                if (hitOrStay == Hit)
                {
                    Card newCard = _game.Deck.GetNextCard();
                    _game.AddCardToPlayer(newCard);
                    _outputWriter.PrintText($"You draw {newCard}\n");
                }
            }
            PrintPlayerHandStatus();
        }

        private int GetPlayerResponse()
        {
            if (_game.PlayerValue >= 21) return Stay;
            _outputWriter.PrintText("\nHit or stay? (Hit = 1, Stay = 0)");
            return _inputReader.GetHitOrStayInput();
        }

        private void PrintPlayerHandStatus()
        {
            _outputWriter.PrintText(_game.PlayerValue > 21
                ? "You are currently at bust!!"
                : $"You are currently at {_game.PlayerValue}");
            _outputWriter.PrintCardsInHand(_game.Player);
        }

        private void ConductDealerTurn()
        {
            _outputWriter.PrintText("\nDealer's Turn");
            PrintDealerHandStatus();
            while (_game.DealerValue <= 17)
            {
                Card newCard = _game.Deck.GetNextCard();
                _game.AddCardToDealer(newCard);
                _outputWriter.PrintText($"\nDealer draws {newCard}");
                PrintDealerHandStatus();
            }
        }
        
        private void PrintDealerHandStatus()
        {
            _outputWriter.PrintText($"Dealer is at {Scorer.CalculateValueOfHand(_game.Dealer)}");
            _outputWriter.PrintCardsInHand(_game.Dealer);
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