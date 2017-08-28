using Framework.Generality;
using Framework.Generality.Bases;
using Framework.Generality.Enemy;
using Framework.Generality.InputControl;
using Framework.Generality.OffSets;
using Framework.Generality.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Framework.MainTank;
using Microsoft.Xna.Framework.Content;
using Framework.Generality.Bases.UI;
using Framework.Generality.Bases.Camera2D;

namespace Framework
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static public ContentManager _content;
        DemoButton demo;
        Camera cam;
        Tank tank;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = Constants.VIEWPORT_WIDTH;
            graphics.PreferredBackBufferHeight = Constants.VIEWPORT_HEIGHT;
            demo = new DemoButton();
            cam = new Camera();
            tank = new Tank();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _content = Content;
            demo.Init(new Vector2(0, 0), new Rectangle(0, 0, 100, 20));
            tank.Init();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            demo.LoadContents(Content, @"font",@"tank");
            tank.LoadContents(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            float elapsedGameTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            demo.Update(elapsedGameTime);
            cam.Update(elapsedGameTime, tank.POSITION);
            tank.Update(elapsedGameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,null,null,null,null,cam.GetTransfromMatrix());
            demo.Draw(spriteBatch);
            tank.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
