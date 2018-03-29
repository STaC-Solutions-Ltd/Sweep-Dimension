using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.GameOverStrategies
{
    public class OnlySpecificPiecesRemainingGameOverStrategy : IGameOverStrategy
    {
        private int _typeID;

        public OnlySpecificPiecesRemainingGameOverStrategy(int typeID)
        {
            _typeID = typeID;
        }

        public bool IsCriteriaMet(IGameState state)
        {
            return state.Pieces.Where(r => r.TypeID == _typeID).All(r => !r.Visible);
        }
    }
}
