using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Models
{
    public class Animation
    {
        public int frameCount { get; set; }
        public float frameSpeed { get; set; }
        public int frameHeight { get { return texture.Height; } }
        public int frameWidth { get { return texture.Width / frameCount; } }
        public Texture2D texture { get; set; }
        public Vector2 size { get; set; }

        public Animation(Texture2D texture, int frameCount, float frameSpeed)
        {
            this.texture = texture;
            this.frameCount = frameCount;
            this.frameSpeed = frameSpeed;
            size = new Vector2(frameWidth, frameHeight);
        }
    }
}
