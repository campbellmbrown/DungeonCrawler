using DungeonCrawler.Managers;
using DungeonCrawler.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Sprite
    {
        protected Texture2D texture { get; set; }
        protected Rectangle sourceRectangle { get; set; }
        protected bool hasSourceRectangle { get; set; }
        public int height 
        { 
            get 
            { 
                if (hasSourceRectangle) 
                    return sourceRectangle.Height; 
                else 
                    return texture.Height; 
            } 
        }
        public int width
        {
            get
            {
                if (hasSourceRectangle)
                    return sourceRectangle.Width;
                else
                    return texture.Width;
            }
        }
        public Vector2 size { get { if (hasAnimation) return animation.size; else return new Vector2(texture.Width, texture.Height); } }
        protected AnimationManager animationManager;
        protected Animation animation;
        protected bool hasAnimation { get { return animationManager != null; } }

        public Sprite(Texture2D texture, Rectangle sourceRectangle)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
            hasSourceRectangle = true;
        }

        public Sprite(Texture2D texture)
        {
            this.texture = texture;
            hasSourceRectangle = false;
        }

        public Sprite(Animation animation)
        {
            this.animation = animation;
            hasSourceRectangle = false;
            animationManager = new AnimationManager(animation);
        }

        public void ChangeAnimation(Animation animation)
        {
            animationManager.Play(animation);
        }

        public void Update(GameTime gameTime)
        {
            if (hasAnimation) animationManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (hasAnimation)
                animationManager.Draw(spriteBatch, position);
            else if (hasSourceRectangle)
                spriteBatch.Draw(texture, position, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
