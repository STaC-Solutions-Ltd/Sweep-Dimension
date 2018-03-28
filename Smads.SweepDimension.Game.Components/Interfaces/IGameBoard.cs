using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components.Interfaces
{
    public interface IGameBoard
    {
        IEnumerable<int> Dimensions { get; }

        int NoOfDimensions { get; }

        int Sides { get; }

        int GetLocationCount();

        IEnumerable<IEnumerable<int>> GetAdjacentLocations(IEnumerable<int> location);

        void PlacePiece(IGamePiece piece, IEnumerable<int> location);

        IEnumerable<int> GetPiecesLocation(IGamePiece piece);

        IEnumerable<IGamePiece> GetPiecesInLocation(IEnumerable<int> location);

        IEnumerable<IGamePiece> GetAdjacentPieces(IGamePiece piece);

        void MovePiece(IGamePiece piece, IEnumerable<int> destLocation);

        void RemovePiece(IGamePiece piece);
    }
}
