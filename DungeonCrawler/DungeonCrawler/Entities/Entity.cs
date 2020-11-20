using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Entities
{
    public class Entity
    {
        protected Sprite sprite { get; set; }
        public Vector2 position { get; set; }
        public RectangleF collisionRectangle { get { return new RectangleF(position.X, position.Y, sprite.width, sprite.height); } }

        public Entity(Vector2 position)
        {
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}
