using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components
{
    public class GameState : IGameState
    {
        public IEnumerable<IGamePiece> Pieces { get; private set; }
        public IGameRules Rules { get; private set; }
        public IGameBoard Board { get; private set; }
        public DateTime StartTime { get; private set; }
        public TimeSpan ElapsedTime { get { return EndTime - StartTime; } }
        public DateTime EndTime { get; private set; }
        public double Score { get; private set; }

        public GameState(IGameBoard board, IEnumerable<IGamePiece> pieces, IGameRules rules)
        {
            Board = board;
            Pieces = pieces;
            Rules = rules;
        }

        public void StartGame()
        {
            if (StartTime != DateTime.MinValue)
            {
                throw new InvalidOperationException("Game is already started.");
            }

            StartTime = DateTime.Now;
        }

        public void EndGame()
        {
            if (StartTime == DateTime.MinValue)
            {
                throw new InvalidOperationException("Game is not started.");
            }

            EndTime = DateTime.Now;
        }

        public void CalculateScore()
        {
            Score = Rules.CalculateScore(this);
        }

        public void UpdateState()
        {
            CalculateScore();

            var win = Rules.WinConditionMet(this);
            var lose = Rules.LoseConditionMet(this);

            if((win || lose) && StartTime != DateTime.MinValue && EndTime == DateTime.MinValue)
            {
                EndGame();
            }
        }
    }
}
