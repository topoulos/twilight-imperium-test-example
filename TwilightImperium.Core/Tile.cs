using System;
using System.Collections.Generic;
using System.Text;

namespace TwilightImperium.Core
{
    public class Tile
    {
        private readonly TileType tileType;

        public bool IsMecatolRex => tileType == TileType.MecatolRex;
        public bool IsHomeSystem => tileType == TileType.HomeSystem;

        public Tile(TileType tileType)
        {
            this.tileType = tileType;
        }
    }
}
