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
        protected List<Floor> floors { get; set; }
        public Floor currentFloor { get; set; }

        public FloorManager()
        {
            floors = new List<Floor>();
            floors.Add(new Floor());
            currentFloor = floors[0];
        }

        public void Update(GameTime gameTime)
        {
            currentFloor.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentFloor.Draw(spriteBatch);
        }
    }
}
