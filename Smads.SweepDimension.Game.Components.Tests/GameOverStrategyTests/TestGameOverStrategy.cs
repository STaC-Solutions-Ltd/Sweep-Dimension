using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Tests.GameOverStrategyTests
{
    public class TestGameOverStrategy : IGameOverStrategy
    {
        bool _output;

        public TestGameOverStrategy(bool output)
        {
            _output = output;
        }

        public bool IsCriteriaMet(IGameState state)
        {
            return _output;
        }
    }
}
