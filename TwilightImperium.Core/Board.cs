using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace TwilightImperium.Core
{
    public class Board
    {
        private readonly int outerRingNumber = 3;
        private readonly int[] homeSystemPositions = { 0, 3, 6, 9, 12, 15 };
        private readonly List<Tuple<Tile, TileCoordinate>> tiles = new List<Tuple<Tile, TileCoordinate>>();

        public bool CanPlaceTile(Tile tile, TileCoordinate tileCoordinate)
        {
            if (tile.IsMecatolRex)
            {
                return IsGalacticCenter(tileCoordinate);
            }

            if (tile.IsHomeSystem)
            {
                return IsHomeSystemPosition(tileCoordinate);
            }

            return false;
        }

        private bool IsGalacticCenter(TileCoordinate tileCoordinate)
        {
            return tileCoordinate.TilePosition == 0 && tileCoordinate.RingNumber == 0;
        }

        private bool IsHomeSystemPosition(TileCoordinate tileCoordinate)
        {
            return tileCoordinate.RingNumber == outerRingNumber && homeSystemPositions.Contains(tileCoordinate.TilePosition);
        }

        public void AddTile(Tile tile, TileCoordinate tileCoordinate)
        {
            if (!CanPlaceTile(tile, tileCoordinate))
            {
                throw new InvalidOperationException();
            }

            tiles.Add(new Tuple<Tile, TileCoordinate>(tile, tileCoordinate));
        }

        public bool HasTileAtPosition(Tile tile,TileCoordinate tileCoordinate)
        {
            return tiles.Any(x => x.Item1 == tile && x.Item2.Equals(tileCoordinate));
        }
    }
}
