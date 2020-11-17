using DungeonCrawler.Tiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Models
{
    public class Barrier
    {
        protected Tile tile { get; set; }
        public Rectangle collisionRectangle { get; set; }

        public Barrier(Tile tile)
        {
            this.tile = tile;
            this.collisionRectangle = new Rectangle((int)tile.position.X, (int)tile.position.Y, tile.width, tile.height);
        }
    }
}
