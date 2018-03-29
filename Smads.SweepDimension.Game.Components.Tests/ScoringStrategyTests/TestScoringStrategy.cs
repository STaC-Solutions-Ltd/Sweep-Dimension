using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Tests.ScoringStrategyTests
{
    public class TestScoringStrategy : IScoringStrategy
    {
        int _output;

        public TestScoringStrategy(int output)
        {
            _output = output;
        }

        public int CalculateScore(IGameState state)
        {
            return _output;
        }
    }
}
