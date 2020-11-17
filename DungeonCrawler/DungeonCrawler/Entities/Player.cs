using DungeonCrawler.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Entities
{
    public class Player : Entity
    {
        public float playerSpeed = 65f;
        public Vector2 center { get { return position + sprite.size / 2f; } }
        public Rectangle collisionRectangle { get { return new Rectangle((int)position.X, (int)position.Y, sprite.width, sprite.height); } }
        
        public Player(Vector2 position) : base(position)
        {
            sprite = new Sprite(Game1.textures["player"]);
        }

        public void Move(Vector2 playerDirection, float t, List<Barrier> barriers)
        {
            Vector2 potentialDisplacement = playerDirection * playerSpeed * t;
            Rectangle newCollisionRectangle = new Rectangle(
                collisionRectangle.X + (int)potentialDisplacement.X, 
                collisionRectangle.Y + (int)potentialDisplacement.Y, 
                collisionRectangle.Width, 
                collisionRectangle.Height);
            foreach (var barrier in barriers)
            {
                if (barrier.collisionRectangle.Intersects(newCollisionRectangle))
                    return;
            }

            position += potentialDisplacement;
        }
    }
}
