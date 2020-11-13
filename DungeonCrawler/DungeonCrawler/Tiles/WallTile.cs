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
        protected Dictionary<string, Rectangle> wallTileType = new Dictionary<string, Rectangle>()
        {
            { "top_wall", new Rectangle(0, 0, 12, 12) },
            { "bottom_wall", new Rectangle(12, 0, 12, 12) },
            { "left_wall", new Rectangle(24, 0, 12, 12) },
            { "right_wall", new Rectangle(36, 0, 12, 12) },
            { "TR_corner", new Rectangle(0, 12, 12, 12) },
            { "TL_corner", new Rectangle(12, 12, 12, 12) },
            { "BL_corner", new Rectangle(24, 12, 12, 12) },
            { "BR_corner", new Rectangle(36, 12, 12, 12) }
        };

        public WallTile(Vector2 position) : base(position)
        {
            sprite = new Sprite(Game1.textures["wall_tiles_1"], wallTileType["top_wall"]);
        }
    }
}
