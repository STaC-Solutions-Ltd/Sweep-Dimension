using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components
{
    public class GamePiece : IGamePiece
    {
        public int TypeID { get; private set; }

        public string TypeName { get; private set; }

        private IMovementStrategy _movementStrategy;

        public bool Visible { get; private set; }

        /// <summary>
        /// Create a new GamePiece
        /// </summary>
        /// <param name="sides">No of sides the game piece should have.</param>
        /// <param name="mainState">Default or alt state</param>
        /// <param name="visible">Set initial piece visibility</param>
        public GamePiece(int typeID, string typeName, IMovementStrategy movementStrategy, bool visible)
        {
            TypeID = typeID;
            TypeName = typeName;
            Visible = visible;
            _movementStrategy = movementStrategy;
        }

        /// <summary>
        /// Toggle Visibility
        /// </summary>
        public void ToggleVisibility()
        {
            Visible = !Visible;
        }

        public IEnumerable<int[]> LegalMoves()
        {
            return _movementStrategy.GetLegalMoves();
        }
    }
}
