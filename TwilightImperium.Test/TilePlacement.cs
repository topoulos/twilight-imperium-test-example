using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwilightImperium.Core;

// Tile Placement Rules ***
// If the tile ring around the galactic center is not complete, next tile must be placed there
// For each ring, the tile placement must be complete (all tiles filled) before you can proceed to the next outer ring
// You may not place a special system adjacent to another special system unless there are no other options
// SHould only be able to add a tile if it can be placed
// Should be able to add tiles to the board
// Refactor ring number and position to struct
// Tiles may not be placed in positions occupied by other tiles
// Create hash method for TileCoordinate Equals

namespace TwilightImperium.Test
{
    [TestClass]
    public class TilePlacement
    {
        [TestMethod]
        public void Should_Be_Able_To_Add_Tiles_To_Board()
        {
            var board = new Board();
            var tile = new Tile(TileType.MecatolRex);

            board.AddTile(tile, new TileCoordinate(0,0));

            Assert.IsTrue(board.HasTileAtPosition(tile, new TileCoordinate(0,0)));
        }

        [TestMethod]
        public void Tiles_May_Not_Be_Placed_In_Positions_Occupied_By_Other_Tiles()
        {
            var board = new Board();
            var tile = new Tile(TileType.MecatolRex);
            var tile2 = new Tile(TileType.MecatolRex);
            var tileCoordinate = new TileCoordinate(0,0);

            board.AddTile(tile,tileCoordinate);

            Assert.IsFalse(board.CanPlaceTile(tile2, tileCoordinate));
        }
        [TestMethod]
        public void Should_Not_Be_Able_To_Add_Tile_To_Invalid_Position()
        {
            var board = new Board();
            var tile = new Tile(TileType.MecatolRex);
            
            Assert.ThrowsException<InvalidOperationException>(() => board.AddTile(tile, new TileCoordinate(1, 1)));
        }

        [TestMethod]
        public void Inner_Ring_Must_Be_Completed_Before_Tile_Can_Be_Placed()
        {
            //Assert.IsTrue();
        }

        [TestMethod]
        public void Mecatol_Rex_Must_Always_Be_Placed_In_The_Center()
        {
            var mecatolRex = new Tile(TileType.MecatolRex);
            var board = new Board();
            
        
            Assert.IsTrue(board.CanPlaceTile(mecatolRex, new TileCoordinate(0,0)));
            Assert.IsFalse(board.CanPlaceTile(mecatolRex, new TileCoordinate(1, 0)));
        }

        [TestMethod]
        public void Home_System_Tiles_Must_Be_Placed_In_Home_System_Positions()
        {
            var board = new Board();
            var homeSystem = new Tile(TileType.HomeSystem);

            Assert.IsTrue(board.CanPlaceTile(homeSystem, new TileCoordinate(3, 0)));
            Assert.IsTrue(board.CanPlaceTile(homeSystem, new TileCoordinate(3, 3)));
            Assert.IsTrue(board.CanPlaceTile(homeSystem, new TileCoordinate(3, 6)));
            Assert.IsTrue(board.CanPlaceTile(homeSystem, new TileCoordinate(3, 9)));
            Assert.IsTrue(board.CanPlaceTile(homeSystem, new TileCoordinate(3, 12)));
            Assert.IsTrue(board.CanPlaceTile(homeSystem, new TileCoordinate(3, 15)));
            Assert.IsFalse(board.CanPlaceTile(homeSystem,new TileCoordinate(0, 0)));
        }
    }

}
