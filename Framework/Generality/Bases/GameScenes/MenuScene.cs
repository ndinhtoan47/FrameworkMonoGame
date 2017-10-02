using Microsoft.Xna.Framework.Input;
using System;
using Framework.Generality.Managers;
using Framework.Generality.OffSets;
using Framework.Generality.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Framework.Generality.Bases.GameScenes
{
    public class MenuScene : Scene
    {
        public enum menuState
        {
            playButton,
            exitButton,
            soundButton,
        }
        protected Texture2D playButton;
        protected Texture2D exitButton;
        protected Texture2D soundButton;
        protected Texture2D backgroundMenu;
        protected SpriteFont font;
        protected Color colorPlayB;
        protected Color colorExitB;
        protected Color colorSoundB;

        protected Vector2 playButtonPos;
        protected Vector2 exitButtonPos;
        protected Vector2 soundButtonPos;
        protected Rectangle mouseRec;
        public menuState state = GameScenes.MenuScene.menuState.playButton;
        public int stateCount = 0;
        public KeyboardState prekey;
        protected bool down;

        protected SBackground sBG;
        protected SEffect sE;
       

        public MenuScene(ContentManager contents) :
            base(Constants.SCENE_MENU, contents)
        {
            //image = null;
            colorPlayB = new Color(255, 255, 255, 255);
            colorExitB = new Color(255, 255, 255, 255);
            colorSoundB = new Color(255, 255, 255, 255);
            playButtonPos = new Vector2(0, 0);
            exitButtonPos = new Vector2(0, 50);
            soundButtonPos = new Vector2(0, 100);
            sBG = new SBackground();
            sE = new SEffect();
        }

        public override bool Init()
        {
            _isInit = LoadContents();
            return _isInit;
        }
        public override void Shutdown()
        {
            _contents.Unload();
            _isInit = false;
        }
        public override void Draw(SpriteBatch sp)
        {
            sp.Begin();
            sp.Draw(backgroundMenu, new Rectangle(0, 0, 800, 600), Color.White);
            sp.Draw(playButton, new Rectangle((800 / 2) - (this.playButton.Width / 2), (300  / 2) - (this.playButton.Height / 2), playButton.Width, playButton.Height), colorPlayB);
            sp.Draw(exitButton, new Rectangle((800 / 2) - (this.exitButton.Width / 2), (450 / 2) - (this.exitButton.Height / 2), exitButton.Width, exitButton.Height), colorExitB);
            sp.Draw(soundButton, new Rectangle((800 / 2) - (this.soundButton.Width / 2), (600 / 2) - (this.soundButton.Height / 2), soundButton.Width, soundButton.Height), colorSoundB);
            sp.DrawString(font, "PLAY", new Vector2(400, 150), Color.White);
            sp.End();
        }
        public override GameManager.GameState Update(float deltaTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && prekey.IsKeyUp(Keys.Down))
            {
                sE.Play();
                state++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && prekey.IsKeyUp(Keys.Up))
            {
                sE.Play();
                state--;
            }
            prekey = Keyboard.GetState();
            if (state == menuState.playButton)
            {
                if (colorPlayB.A == 255)
                    down = false;
                if (colorPlayB.A == 0)
                    down = true;
                if (down)
                    colorPlayB.A -= 5;
                else colorPlayB.A += 5; 
            }
            else colorPlayB.A = 255;
            if (state == menuState.exitButton)
            {
                if (colorExitB.A == 255)
                    down = false;
                if (colorExitB.A == 0)
                    down = true;
                if (down)
                    colorExitB.A += 3;
                else colorExitB.A -= 3;
            }
            else colorExitB.A = 255;
            if (state == menuState.soundButton)
            {
                if (colorSoundB.A == 255)
                    down = false;
                if (colorSoundB.A == 0)
                    down = true;
                if (down)
                    colorSoundB.A += 3;
                else colorSoundB.A -= 3;
            }
            else colorSoundB.A = 255;
            if ((int)state > 2) state = menuState.playButton;
            if ((int)state < 0) state = menuState.soundButton;
           
            return GameManager.GameState.None;
        }
        public override bool LoadContents()
        {
            playButton = _contents.Load<Texture2D>("menu");
            exitButton = _contents.Load<Texture2D>("menu");
            soundButton = _contents.Load<Texture2D>("menu");
            backgroundMenu = _contents.Load<Texture2D>("mBackground");
            font = _contents.Load<SpriteFont>("menufont");
            sBG.LoadContents(_contents, "sBG");
            sE.LoadContents(_contents, "s_menu_1");
            //sBG.Play();
            return true;
        }


    }
}
