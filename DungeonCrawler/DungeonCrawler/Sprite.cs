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
                else if (hasAnimation)
                    return animation.frameHeight;
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
                else if (hasAnimation)
                    return animation.frameWidth;
                else
                    return texture.Width;
            }
        }
        protected Vector2 rotationSource { get; set; }
        public Vector2 size { get { if (hasAnimation) return animation.size; else return new Vector2(texture.Width, texture.Height); } }
        protected AnimationManager animationManager { get; set; }
        protected Animation animation { get; set; }
        protected bool hasAnimation { get { return animationManager != null; } }

        public enum RotationPoint
        {
            bottomMiddle,
            topLeft,
            center
        }

        public Sprite(Texture2D texture, Rectangle sourceRectangle, RotationPoint rotationSource)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
            hasSourceRectangle = true;
            SetRotationSource(rotationSource);
        }

        public Sprite(Texture2D texture, Rectangle sourceRectangle)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
            hasSourceRectangle = true;
            SetRotationSource(RotationPoint.topLeft);
        }


        public Sprite(Texture2D texture, RotationPoint rotationSource)
        {
            this.texture = texture;
            hasSourceRectangle = false;
            SetRotationSource(rotationSource);

        }

        public Sprite(Texture2D texture)
        {
            this.texture = texture;
            hasSourceRectangle = false;
            SetRotationSource(RotationPoint.topLeft);
        }

        public Sprite(Animation animation, RotationPoint rotationSource)
        {
            this.animation = animation;
            hasSourceRectangle = false;
            animationManager = new AnimationManager(animation);
            SetRotationSource(rotationSource);
        }

        public Sprite(Animation animation)
        {
            this.animation = animation;
            hasSourceRectangle = false;
            animationManager = new AnimationManager(animation);
            SetRotationSource(RotationPoint.topLeft);
        }

        public void SetRotationSource(RotationPoint rotationSource)
        {
            switch (rotationSource)
            {
                case RotationPoint.bottomMiddle:
                    this.rotationSource = new Vector2(width / 2f, height);
                    break;
                case RotationPoint.topLeft:
                    this.rotationSource = Vector2.Zero;
                    break;
            }
        }

        public void ChangeAnimation(Animation animation)
        {
            animationManager.Play(animation);
        }

        public void Update(GameTime gameTime)
        {
            if (hasAnimation) animationManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation = 0f)
        {
            if (hasAnimation)
                animationManager.Draw(spriteBatch, position, rotation, rotationSource);
            else if (hasSourceRectangle)
                spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, rotationSource, 1f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(texture, position, null, Color.White, rotation, rotationSource, 1f, SpriteEffects.None, 0f);
        }
    }
}
