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
        protected Vector2 position;
        protected Sprite sprite;

        public Tile(Vector2 position)
        {
            this.position = position;
            sprite = new Sprite(Game1.textures["floor_tiles_1"]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}
