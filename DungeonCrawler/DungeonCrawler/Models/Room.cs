using DungeonCrawler.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Models
{
    public class RoomJSONModel
    {
        public string ID { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public List<int[]> floorPositions { get; set; }
        public List<int[]> wallPositions { get; set; }
    }

    public class Room
    {
        protected List<FloorTile> floorTiles;
        protected List<WallTile> wallTiles;

        public Room(RoomJSONModel roomJSONModel)
        {
            floorTiles = new List<FloorTile>();
            wallTiles = new List<WallTile>();
            JSONModelToObjects(roomJSONModel);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var floorTile in floorTiles)
                floorTile.Draw(spriteBatch);
            foreach (var wallTile in wallTiles)
                wallTile.Draw(spriteBatch);
        }

        public void JSONModelToObjects(RoomJSONModel roomJSONModel)
        {
            foreach (var floorPosition in roomJSONModel.floorPositions)
                floorTiles.Add(new FloorTile(new Vector2(floorPosition.ElementAt(1) * 12, floorPosition.ElementAt(0) * 12)));
            foreach (var wallPosition in roomJSONModel.wallPositions)
                wallTiles.Add(new WallTile(new Vector2(wallPosition.ElementAt(1) * 12, wallPosition.ElementAt(0) * 12)));
        }
    }
}
