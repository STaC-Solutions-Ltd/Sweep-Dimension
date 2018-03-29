using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Interfaces
{
    public  interface IMovementStrategy
    {
        IEnumerable<int[]> GetLegalMoves();
    }
}
