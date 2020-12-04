using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
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
        public Vector2 center { get { return position + sprite.size / 2f; } }
        public Rectangle relCollRect { get; set; }
        public RectangleF collisionRectangle { get { return new RectangleF(relCollRect.X + position.X, relCollRect.Y + position.Y, relCollRect.Width, relCollRect.Height); } }
        public Entity(Vector2 position)
        {
            this.position = position;
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}
