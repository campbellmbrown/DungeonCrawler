using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Models
{
    public class Floor
    {
        protected List<Room> rooms;

        public Floor()
        {
            rooms = new List<Room>();
            rooms.Add(new Room());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var room in rooms)
                room.Draw(spriteBatch);
        }
    }
}
