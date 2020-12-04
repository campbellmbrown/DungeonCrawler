using DungeonCrawler.Managers;
using DungeonCrawler.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics { get; set; }
        private SpriteBatch spriteBatch { get; set; }
        private Color backgroundColor { get; set; }

        public static Dictionary<string, Texture2D> textures { get; set; }
        //public static Dictionary<string, SoundEffect> sounds { get; set; }
        public static Dictionary<string, Animation> animations { get; set; }

        public static Camera2D camera { get; set; }

        public static Vector2 screenSize { get { return new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height); } }
        public Vector2 windowSize { get { return new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height); } }
        public static Vector2 zoomedScreenSize { get { return screenSize / camera.Zoom; } }
        public static Vector2 topLeft { get { return Vector2.Transform(Vector2.Zero, camera.GetInverseViewMatrix()); } }
        public static Vector2 mousePosition
        {
            get
            {
                Point _mousePos = Mouse.GetState().Position;
                return Vector2.Transform(new Vector2(_mousePos.X, _mousePos.Y), camera.GetInverseViewMatrix());
            }
        }
        public static Random r { get; set; }

        // Managers
        public static FloorManager floorManager { get; set; }
        public static InputManager inputManager { get; set; }

        SpriteFont spriteFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = (int)screenSize.X;
            graphics.PreferredBackBufferHeight = (int)screenSize.Y;
            graphics.IsFullScreen = false;
            r = new Random();
        }

        protected override void Initialize()
        {
            IsMouseVisible = false;
            IsFixedTimeStep = true;
            graphics.SynchronizeWithVerticalRetrace = true;
            backgroundColor = new Color(26, 26, 40);
            camera = new Camera2D(GraphicsDevice) { Zoom = 4, Position = (new Vector2(300, 210) - windowSize) / 2f };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textures = new Dictionary<string, Texture2D>() 
            {
                { "floor_tiles_1", Content.Load<Texture2D>("Tiles/floor_tiles_1") },
                { "wall_tiles_1", Content.Load<Texture2D>("Tiles/wall_tiles_1") },
            };
            animations = new Dictionary<string, Animation>()
            {
                { "player_idle_right", new Animation(Content.Load<Texture2D>("Entities/player_idle_right"), 1, 10f) },
                { "player_idle_left", new Animation(Content.Load<Texture2D>("Entities/player_idle_left"), 1, 10f) }
            };

            floorManager = new FloorManager();
            inputManager = new InputManager();

            spriteFont = Content.Load<SpriteFont>("Fonts/File");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            inputManager.Update(gameTime);
            floorManager.Update(gameTime);
            camera.Position = floorManager.currentFloor.player.center - windowSize / 2f;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, transformMatrix: camera.GetViewMatrix()); 
            GraphicsDevice.Clear(backgroundColor);
            floorManager.Draw(spriteBatch);
            spriteBatch.DrawPoint(mousePosition, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
