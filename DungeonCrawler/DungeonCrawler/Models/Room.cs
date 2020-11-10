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
    public class Room
    {
        protected List<FloorTile> floorTiles;
        protected List<WallTile> wallTiles;

        public Room()
        {
            floorTiles = new List<FloorTile>();
            wallTiles = new List<WallTile>();
            for (int i = 0; i < 10; ++i)
                floorTiles.Add(new FloorTile(new Vector2(Game1.r.Next(0, 201), Game1.r.Next(0, 201))));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var floorTile in floorTiles)
                floorTile.Draw(spriteBatch);
            foreach (var wallTile in wallTiles)
                wallTile.Draw(spriteBatch);
        }
    }
}
