using DungeonCrawler.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
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
        protected List<Room> rooms { get; set; }
        public Player player { get; set; }
        protected List<Barrier> barriers { get; set; }

        public Floor()
        {
            rooms = new List<Room>();
            player = new Player(new Vector2(30, 30));
            barriers = new List<Barrier>();
            GenerateRooms();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var room in rooms)
                room.Update(gameTime);
            player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var room in rooms)
                room.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }

        public void GenerateRooms()
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            string strJSON = System.IO.File.ReadAllText(@"D:\Git Projects\DungeonCrawler\DungeonCrawler\DungeonCrawler\Rooms\room_1.txt");
            rooms.Add(new Room(DeserialiseJSON(strJSON)));

            foreach (var room in rooms)
            {
                foreach (var wallTile in room.wallTiles)
                { 
                    barriers.Add(new Barrier(wallTile)); 
                }
            }
        }

        private RoomJSONModel DeserialiseJSON(string strJSON)
        {
            RoomJSONModel roomJSONModel = JsonConvert.DeserializeObject<RoomJSONModel>(strJSON);
            return roomJSONModel;
        }

        public void MovePlayer(Vector2 playerDirection, float t)
        {
            player.Move(playerDirection, t, barriers);
        }
    }
}
