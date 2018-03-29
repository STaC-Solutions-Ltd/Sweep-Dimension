using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.GameOverStrategies
{
    public class SpecificPieceVisibleGameOverStrategy : IGameOverStrategy
    {
        private int _typeID;

        public SpecificPieceVisibleGameOverStrategy(int typeID)
        {
            _typeID = typeID;
        }

        public bool IsCriteriaMet(IGameState state)
        {
            return state.Pieces.Any(r => r.Visible && r.TypeID == _typeID);
        }
    }
}
