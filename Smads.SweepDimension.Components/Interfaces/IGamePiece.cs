using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Interfaces
{
    interface IGamePiece
    {
        int Sides { get; set; }

        IEnumerable<IGamePiece> LinkedPieces { get; set; }

        int MainState { get; set; }

        int AltState { get; set; }

        int CurrentState { get; set; }

        bool Visible { get; set; }

        void ToggleState();
    }
}
