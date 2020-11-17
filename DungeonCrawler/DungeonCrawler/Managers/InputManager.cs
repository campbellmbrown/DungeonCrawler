using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Managers
{
    public class InputManager
    {
        public InputManager()
        {
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            CheckHeldKeyPress(keyboardState, t);
        }

        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {
            int x = 0;
            int y = 0;
            if (keyboardState.IsKeyDown(Keys.W)) y -= 1;
            if (keyboardState.IsKeyDown(Keys.A)) x -= 1;
            if (keyboardState.IsKeyDown(Keys.S)) y += 1;
            if (keyboardState.IsKeyDown(Keys.D)) x += 1;
            Vector2 playerDirection = new Vector2(x, y);
            if (x != 0 || y != 0) playerDirection.Normalize();
            Game1.floorManager.currentFloor.MovePlayer(playerDirection, t);
        }
    }
}
