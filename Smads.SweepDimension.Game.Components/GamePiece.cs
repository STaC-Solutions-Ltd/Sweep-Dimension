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
        public int Sides { get; private set; }

        public bool MainState { get; private set; }

        public bool Visible { get; private set; }

        /// <summary>
        /// Create a new GamePiece
        /// </summary>
        /// <param name="sides">No of sides the game piece should have.</param>
        /// <param name="mainState">Default or alt state</param>
        /// <param name="visible">Set initial piece visibility</param>
        public GamePiece(int sides, bool mainState, bool visible)
        {
            Sides = sides;
            MainState = mainState;
            Visible = visible;
        }

        /// <summary>
        /// Toggle State 
        /// </summary>
        public void ToggleState()
        {
            MainState = !MainState;
        }

        /// <summary>
        /// Toggle Visibility
        /// </summary>
        public void ToggleVisibility()
        {
            Visible = !Visible;
        }
    }
}
