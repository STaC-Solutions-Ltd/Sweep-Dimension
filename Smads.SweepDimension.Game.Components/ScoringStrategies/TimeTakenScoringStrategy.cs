using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.ScoringStrategies
{
    public class TimeTakenScoringStrategy : IScoringStrategy
    {
        public int CalculateScore(IGameState state)
        {
            return (int)state.ElapsedTime.TotalSeconds;
        }
    }
}
