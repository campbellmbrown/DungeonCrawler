using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Tiles
{
    public class WallTile : Tile
    {
        public WallTile(Vector2 position, int mask) : base(position)
        {
            sprite = new Sprite(Game1.textures["wall_tiles_1"], new Rectangle((mask % 8) * 12, (mask / 8) * 12, 12, 12));
        }
    }
}
