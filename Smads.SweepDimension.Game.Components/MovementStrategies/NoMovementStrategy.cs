using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.MovementStrategies
{
    public class NoMovementStrategy : IMovementStrategy
    {
        public IEnumerable<int[]> GetLegalMoves()
        {
            return new List<int[]>();
        }
    }
}
