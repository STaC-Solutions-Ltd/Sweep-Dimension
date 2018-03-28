using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Interfaces
{
    public interface IGameState
    {
        IEnumerable<IGamePiece> Pieces { get; }

        IGameRules Rules { get; }

        IGameBoard Board { get; }

        DateTime StartTime { get; }

        TimeSpan ElapsedTime { get; }

        DateTime EndTime { get; }

        Double Score { get; }

        void UpdateState();
         
        void StartGame();

        void EndGame();

        void CalculateScore();
    }
}
