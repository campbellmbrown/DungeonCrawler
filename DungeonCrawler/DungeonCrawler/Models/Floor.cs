using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
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
            GenerateRooms();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var room in rooms)
                room.Draw(spriteBatch);
        }

        public void GenerateRooms()
        {
            string strJSON = System.IO.File.ReadAllText(@"D:\Git Projects\DungeonCrawler\DungeonCrawler\DungeonCrawler\Rooms\room_1.txt");
            rooms.Add(new Room(DeserialiseJSON(strJSON)));
        }

        private RoomJSONModel DeserialiseJSON(string strJSON)
        {
            // TODO - change this method
            RoomJSONModel roomJSONModel = JsonConvert.DeserializeObject<RoomJSONModel>(strJSON);
            return roomJSONModel;
        }
    }
}
