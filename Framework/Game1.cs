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
using Framework.Generality.Bases.Camera2D;
using Microsoft.Xna.Framework.Content;
using Framework.Generality.Bases.ParticleSystem;
using Framework.Generality.Particles;
using Framework.Generality.Manager;
using Framework.Generality.Bases.GameScenes;
using Framework.Generality.Bases.UI;

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
        SceneManager sceneManager;
        GateControl Gate;
        DemoButton button;
        LoginScene Login;
        
        public Game1()
        {
            Login = new LoginScene(Content);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = Constants.VIEWPORT_WIDTH;
            graphics.PreferredBackBufferHeight = Constants.VIEWPORT_HEIGHT;
            Gate = new GateControl(Content);
            button = new DemoButton();
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
            sceneManager = new SceneManager(Content);
            sceneManager.Add(new PlayScene(Content));
            sceneManager.Add(new MenuScene(Content));
            sceneManager.Add(new OverScene(Content));
            sceneManager.Add(new LoginScene(Content));
            sceneManager.Init();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            button.LoadContents(Content, "font", "Bullet3");
            Login.LoadContents();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            sceneManager.Update(deltaTime);
            Gate.Updata((float)gameTime.ElapsedGameTime.TotalSeconds);
            button.Update(deltaTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Login.Draw(spriteBatch);
            GraphicsDevice.Clear(Color.Green);
            sceneManager.Draw(spriteBatch);

            spriteBatch.Begin();
            button.Draw(spriteBatch);
            Gate.Draw(spriteBatch);
            spriteBatch.End();

               
            base.Draw(gameTime);
        }
    }
}
