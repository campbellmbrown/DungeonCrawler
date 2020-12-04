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
        public HorizontalDirection horizontalDirection;

        public Player(Vector2 position) : base(position)
        {
            sprite = new Sprite(Game1.animations["player_idle_right"]);
            horizontalDirection = HorizontalDirection.right;
            relCollRect = new Rectangle(1, 6, 5, 3);
        }

        public enum HorizontalDirection
        {
            left,
            right
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

            if (potentialDisplacement.X > 0.001 && horizontalDirection == HorizontalDirection.left)
            {
                horizontalDirection = HorizontalDirection.right;
                sprite.ChangeAnimation(Game1.animations["player_idle_right"]);
            }
            else if (potentialDisplacement.X < -0.001 && horizontalDirection == HorizontalDirection.right)
            {
                horizontalDirection = HorizontalDirection.left;
                sprite.ChangeAnimation(Game1.animations["player_idle_left"]);
            }

            position += potentialDisplacement;
        }
    }
}
