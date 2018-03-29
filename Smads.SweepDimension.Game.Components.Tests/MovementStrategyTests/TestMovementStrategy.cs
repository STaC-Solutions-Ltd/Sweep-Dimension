using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Tests.MovementStrategyTests
{
    public class TestMovementStrategy : IMovementStrategy
    {
        IEnumerable<int[]> _output;

        public TestMovementStrategy(IEnumerable<int[]> output)
        {
            _output = output;
        }

        public IEnumerable<int[]> GetLegalMoves()
        {
            return _output;
        }
    }
}
