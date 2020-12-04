using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Tiles
{
    public class Tile
    {
        public Vector2 position { get; set; }
        protected Sprite sprite { get; set; }
        public int width { get { return sprite.width; } }
        public int height { get { return sprite.height; } }
        public static int tileSize = 6;

        public Tile(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}
