using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Tiles
{
    public class FloorTile : Tile
    {
        public FloorTile(Vector2 position) : base(position)
        {
            sprite = new Sprite(Game1.textures["floor_tiles_1"], new Rectangle(0, 0, 12, 12));
        }
    }
}
