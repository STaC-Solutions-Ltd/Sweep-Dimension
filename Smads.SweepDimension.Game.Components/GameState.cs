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
        public TimeSpan ElapsedTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public double Score { get; private set; }

        public GameState(IGameBoard board, IEnumerable<IGamePiece> pieces, IGameRules rules)
        {
            Board = board;
            Pieces = pieces;
            Rules = rules;
        }

        public void CalculateScore()
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
