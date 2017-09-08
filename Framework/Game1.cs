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
using Framework.Generality.Bases.Camera2D;
using Framework.Generality.Bases.ParticleSystem;

namespace Framework
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Tank newTank;
        Enemy monster;
        Map map1;
        Camera cam;
        ParticleSystem par;
        static public ContentManager _content;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = Constants.VIEWPORT_WIDTH;
            graphics.PreferredBackBufferHeight = Constants.VIEWPORT_HEIGHT;
            newTank = new Tank();
            monster = new Enemy();
            cam = new Camera();
            
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
            map1 = new Map();
            //map1.Init(map1.LoadFileMap(@"../../../../Maps/map1.txt"),64);
            //map1.Init(new int[,] {  {1,1,2,3 },
            //                        {2,2,4,2 },
            //                        {2,3,1,0 }, }, 64);

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
            newTank.LoadContents(Content);
            monster.LoadContents(Content);
            //map1.LoadContents(Content);
            par = new ParticleSystem(new System.Collections.Generic.List<Texture2D>() {
            Content.Load<Texture2D>(@"shape53"),
            Content.Load<Texture2D>(@"shape54"),
            Content.Load<Texture2D>(@"shape55"),
            Content.Load<Texture2D>(@"shape56"),
            Content.Load<Texture2D>(@"shape57"),
            Content.Load<Texture2D>(@"shape58"),
            Content.Load<Texture2D>(@"shape59"),
            Content.Load<Texture2D>(@"shape60"),
            Content.Load<Texture2D>(@"shape61")});
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
            newTank.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            cam.Update((float)gameTime.ElapsedGameTime.TotalSeconds,newTank.POSITION);
            monster.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            par.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            if(Input.Clicked(Constants.MOUSEBUTTON_LEFT))
            {
                par.Add();
            }
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
            newTank.Draw(spriteBatch);
            monster.Draw(spriteBatch);
            map1.Draw(spriteBatch);
            par.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
