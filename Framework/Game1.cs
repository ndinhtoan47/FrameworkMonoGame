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

namespace Framework
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D backg;
        Camera cam;
        Map map;
        FirePar firePar;
        ExplosionPar explosionPar;
        Texture2D tree;
        static public ContentManager _content;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = Constants.VIEWPORT_WIDTH;
            graphics.PreferredBackBufferHeight = Constants.VIEWPORT_HEIGHT;
            cam = new Camera();
            map = new Map();
            firePar = new FirePar();
            explosionPar = new ExplosionPar();
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
            map.Init(map.LoadFileMap(@"../../../../Maps\map1.data"),20);
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
            map.LoadContents(Content);
            backg = Content.Load<Texture2D>("backg");
            firePar.LoadContents(Content);
            explosionPar.LoadContents(Content);
            tree = Content.Load<Texture2D>(@"Tiles\2");
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
            //cam.Update(deltaTime,new Vector2(400,300));
            //if (Input.Clicked(Constants.MOUSEBUTTON_LEFT))
            //    cam.ZoomIn();
            //if (Input.Clicked(Constants.MOUSEBUTTON_RIGHT))
            //    cam.ZoomOut();
            firePar.Update(deltaTime);
            explosionPar.Update(deltaTime);
            
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
            //spriteBatch.Draw(backg, new Vector2(0, 0), Color.White);
            //map.Draw(spriteBatch);
            
            spriteBatch.Draw(tree, new Rectangle(80, 70, 40, 40), new Color(100,100,100,255));
            explosionPar.Draw(spriteBatch);
            firePar.Draw(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
