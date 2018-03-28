using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Interfaces
{
    public interface IGamePiece
    {
        int Sides { get;  }

        bool MainState { get; }

        bool Visible { get; }

        void ToggleState();

        void ToggleVisibility();
    }
}
