using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Interfaces
{
    public interface IGamePiece
    {
        int TypeID { get; }

        string TypeName { get; }

        bool Visible { get; }

        void ToggleVisibility();

        IEnumerable<int[]> LegalMoves();
    }
}
