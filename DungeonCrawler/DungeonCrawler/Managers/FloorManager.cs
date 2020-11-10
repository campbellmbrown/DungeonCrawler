using DungeonCrawler.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Managers
{
    public class FloorManager
    {
        protected List<Floor> floors;

        public FloorManager()
        {
            floors = new List<Floor>();
            floors.Add(new Floor());
        }

        public void Update(GameTime gameTime)
        {
            // TODO
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            floors[0].Draw(spriteBatch);
        }
    }
}
