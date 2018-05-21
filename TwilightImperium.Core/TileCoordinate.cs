using System;
using System.Collections.Generic;
using System.Text;

namespace TwilightImperium.Core
{
    public struct TileCoordinate
    {
        public int RingNumber { get; }
        public int TilePosition { get; }

        public TileCoordinate(int ringNumber, int tilePosition)
        {
            RingNumber = ringNumber;
            TilePosition = tilePosition;
        }

        public override bool Equals(object obj)
        {
            var tileCoordinate = (TileCoordinate) obj;
            return tileCoordinate.RingNumber == RingNumber && tileCoordinate.TilePosition == TilePosition;
        }
    }
}
