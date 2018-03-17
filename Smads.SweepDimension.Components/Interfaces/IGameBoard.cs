using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Interfaces
{
    interface IGameBoard
    {
        int NoOfDimensions { get; set; }

        double Dimensions { get; set; }

        int Sides { get; set; }

        int GetTileCount { get; }

        void GetAdjacentTiles();
    }
}
