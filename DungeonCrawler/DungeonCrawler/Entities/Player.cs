using DungeonCrawler.Models;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
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
        
        public Player(Vector2 position) : base(position)
        {
            sprite = new Sprite(Game1.textures["player"]);
        }

        public void Move(Vector2 playerDirection, float t, List<Barrier> barriers)
        {
            Vector2 potentialDisplacement = playerDirection * playerSpeed * t;
            RectangleF newCollisionRectangleVert = new RectangleF(
                collisionRectangle.X, 
                collisionRectangle.Y + potentialDisplacement.Y, 
                collisionRectangle.Width, 
                collisionRectangle.Height);
            RectangleF newCollisionRectangleHoriz = new RectangleF(
                collisionRectangle.X + potentialDisplacement.X,
                collisionRectangle.Y,
                collisionRectangle.Width,
                collisionRectangle.Height);
            foreach (var barrier in barriers)
            {
                Rectangle c2 = barrier.collisionRectangle;
                if (newCollisionRectangleVert.Intersects(c2))
                    potentialDisplacement.Y = 0;
                if (newCollisionRectangleHoriz.Intersects(c2))
                    potentialDisplacement.X = 0;
            }
            position += potentialDisplacement;
        }
    }
}
