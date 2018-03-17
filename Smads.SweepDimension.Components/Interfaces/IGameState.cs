using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Interfaces
{
    interface IGameState
    {
        IEnumerable<IGamePiece> Pieces { get; set; }

        IGameRules Rules { get; set; }

        IGameBoard Board { get; set; }

        DateTime StartTime { get; set; }

        TimeSpan ElapsedTime { get; set; }

        DateTime EndTime { get; set; }

        Double Score { get; set; }

        void UpdateState();

        void StartGame();

        void EndGame();

        void CalculateScore();
    }
}
