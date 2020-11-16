using DungeonCrawler.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Models
{
    public class RoomJSONModel
    {
        public string ID { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public List<int[]> floorPositions { get; set; }
        public List<int[]> wallPositions { get; set; }
    }

    public class Room
    {
        protected List<FloorTile> floorTiles;
        protected List<WallTile> wallTiles;
        protected Dictionary<int, int> maskRemap = new Dictionary<int, int>()
        {
            { 2, 1 },
            { 8, 2 },
            { 10, 3 },
            { 11, 4 },
            { 16, 5 },
            { 18, 6 },
            { 22, 7 },
            { 24, 8 },
            { 26, 9 },
            { 27, 10 },
            { 30, 11 },
            { 31, 12 },
            { 64, 13 },
            { 66, 14 },
            { 72, 15 },
            { 74, 16 },
            { 75, 17 },
            { 80, 18 },
            { 82, 19 },
            { 86, 20 },
            { 88, 21 },
            { 90, 22 },
            { 91, 23 },
            { 94, 24 },
            { 95, 25 },
            { 104, 26 },
            { 106, 27 },
            { 107, 28 },
            { 120, 29 },
            { 122, 30 },
            { 123, 31 },
            { 126, 32 },
            { 127, 33 },
            { 208, 34 },
            { 210, 35 },
            { 214, 36 },
            { 216, 37 },
            { 218, 38 },
            { 219, 39 },
            { 222, 40 },
            { 223, 41 },
            { 248, 42 },
            { 250, 43 },
            { 251, 44 },
            { 254, 45 },
            { 255, 46 },
            { 0, 47 }
        };

        public Room(RoomJSONModel roomJSONModel)
        {
            floorTiles = new List<FloorTile>();
            wallTiles = new List<WallTile>();
            JSONModelToObjects(roomJSONModel);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var floorTile in floorTiles)
                floorTile.Draw(spriteBatch);
            foreach (var wallTile in wallTiles)
                wallTile.Draw(spriteBatch);
        }

        public void JSONModelToObjects(RoomJSONModel roomJSONModel)
        {
            List<int[]> floorPosL = roomJSONModel.floorPositions;
            List<int[]> wallPosL = roomJSONModel.wallPositions;

            foreach (var floorPos in floorPosL)
            {
                int mask = 0;
                if (PositionInList(floorPosL, floorPos, -1, 0)) mask += 1;
                if (PositionInList(floorPosL, floorPos, 0, -1)) mask += 2;
                if (PositionInList(floorPosL, floorPos, 0, 1)) mask += 4;
                if (PositionInList(floorPosL, floorPos, 1, 0)) mask += 8;
                floorTiles.Add(new FloorTile(new Vector2(floorPos.ElementAt(1) * 12, floorPos.ElementAt(0) * 12), mask));
            }
            foreach (var wallPos in wallPosL)
            {
                int mask = 0;
                bool left = PositionInList(wallPosL, wallPos, 0, -1) || PositionInList(floorPosL, wallPos, 0, -1);
                bool right = PositionInList(wallPosL, wallPos, 0, 1) || PositionInList(floorPosL, wallPos, 0, 1);
                bool up = PositionInList(wallPosL, wallPos, -1, 0) || PositionInList(floorPosL, wallPos, -1, 0);
                bool down = PositionInList(wallPosL, wallPos, 1, 0) || PositionInList(floorPosL, wallPos, 1, 0);
                bool upLeft = PositionInList(wallPosL, wallPos, -1, -1) || PositionInList(floorPosL, wallPos, -1, -1);
                bool upRight = PositionInList(wallPosL, wallPos, -1, 1) || PositionInList(floorPosL, wallPos, -1, 1);
                bool downLeft = PositionInList(wallPosL, wallPos, 1, -1) || PositionInList(floorPosL, wallPos, 1, -1);
                bool downRight = PositionInList(wallPosL, wallPos, 1, 1) || PositionInList(floorPosL, wallPos, 1, 1);
                if (upLeft && left && up) mask += 1;
                if (up) mask += 2;
                if (upRight && right && up) mask += 4;
                if (left) mask += 8;
                if (right) mask += 16;
                if (downLeft && left && down) mask += 32;
                if (down) mask += 64;
                if (downRight && right && down) mask += 128;
                wallTiles.Add(new WallTile(new Vector2(wallPos.ElementAt(1) * 12, wallPos.ElementAt(0) * 12), maskRemap[mask]));
            }
        }

        protected bool PositionInList(List<int[]> list, int[] item, int off0, int off1)
        {
            return list.Any(p => p.SequenceEqual(new int[] { item.ElementAt(0) + off0, item.ElementAt(1) + off1 }));
        }
    }
}
