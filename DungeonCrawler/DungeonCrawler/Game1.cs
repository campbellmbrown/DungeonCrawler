using DungeonCrawler.Managers;
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
        //public static Dictionary<string, Animation> animations { get; set; }

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
        public static Random r;

        // Managers
        public FloorManager floorManager;

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
            camera = new Camera2D(GraphicsDevice) { Zoom = 3, Position = (new Vector2(300, 210) - windowSize) / 2f };
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

            floorManager = new FloorManager();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
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
