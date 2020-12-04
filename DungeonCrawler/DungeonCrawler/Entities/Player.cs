using DungeonCrawler.Models;
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
    public class Player : Entity
    {
        public float playerSpeed = 65f;
        public HorizontalDirection horizontalDirection;
        protected Vector2 previousDisplacement;

        public Player(Vector2 position) : base(position)
        {
            sprite = new Sprite(Game1.animations["player_idle_right"], Sprite.RotationPoint.bottomMiddle);
            horizontalDirection = HorizontalDirection.right;
            relCollRect = new Rectangle(1, 6, 5, 3);
            previousDisplacement = Vector2.Zero;
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

            if (potentialDisplacement.Length() > 0.001)
            {
                // Play movement animations
                if (potentialDisplacement.X > 0.001)
                    horizontalDirection = HorizontalDirection.right;
                else if (potentialDisplacement.X < -0.001)
                    horizontalDirection = HorizontalDirection.left;
                if (horizontalDirection == HorizontalDirection.right)
                    sprite.ChangeAnimation(Game1.animations["player_walk_right"]);
                else if (horizontalDirection == HorizontalDirection.left)
                    sprite.ChangeAnimation(Game1.animations["player_walk_left"]);
            }
            else
            {   
                // Play idle animations
                if (horizontalDirection == HorizontalDirection.left)
                    sprite.ChangeAnimation(Game1.animations["player_idle_left"]);
                else if (horizontalDirection == HorizontalDirection.right)
                    sprite.ChangeAnimation(Game1.animations["player_idle_right"]);
            }

            position += potentialDisplacement;
            previousDisplacement = potentialDisplacement;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (previousDisplacement.Length() > 0.001)
                sprite.Draw(spriteBatch, position, 0.1f * (float)Math.Sin(2*Math.PI*rotateTime/rotatePeriod));
            else
                base.Draw(spriteBatch);
        }

        protected float rotateTime = 0f;
        protected float rotatePeriod = 0.4f;

        public override void Update(GameTime gameTime)
        {
            if (previousDisplacement.Length() > 0.001)
                rotateTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            else
                rotateTime = 0f;
            base.Update(gameTime);
        }
    }
}
