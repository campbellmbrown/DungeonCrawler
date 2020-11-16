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
        public FloorTile(Vector2 position, int mask) : base(position)
        {
            sprite = new Sprite(Game1.textures["floor_tiles_1"], new Rectangle((mask % 4) * 12, (mask / 4) * 12, 12, 12));
        }
    }
}
