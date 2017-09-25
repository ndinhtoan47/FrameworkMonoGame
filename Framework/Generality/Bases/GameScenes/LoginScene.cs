using Framework.Generality.Managers;
using Framework.Generality.OffSets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Framework.Generality.Bases.GameScenes
{
    public class LoginScene : Scene
    {
        protected Texture2D background;
        protected Texture2D namebox;
        protected Keys[] lastPressedKeys = new Keys[5];
        protected string name = string.Empty;
        protected SpriteFont font;
        protected string f_name;
        protected KeyboardState prekey;
        
        public LoginScene(ContentManager contents) :
            base(Constants.SCENE_LOGIN, contents)
        {
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
            sp.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            sp.Draw(namebox, new Rectangle((800 / 2) - (this.namebox.Width / 2), (600 / 2) - (this.namebox.Height / 2), this.namebox.Width, this.namebox.Height), Color.White);
            sp.DrawString(font, name, new Vector2(305, 280), Color.Black);
        }
        public override GameManager.GameState Update(float deltaTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && prekey.IsKeyUp(Keys.Enter))
            {
                if (name.Length > 3)
                {
                    f_name = name;
                }
            }

            prekey = Keyboard.GetState();
            GetKey();
            return GameManager.GameState.None;
        }
        public void GetKey()
        {
            KeyboardState kbState = Keyboard.GetState();
            Keys[] pressedKeys = kbState.GetPressedKeys();
            foreach (Keys key in lastPressedKeys)
            {
                if (!pressedKeys.Contains(key))
                { 
                    OnKeyUp(key);
                }

            }
            foreach(Keys key in pressedKeys)
            {
                if (!lastPressedKeys.Contains(key))
                {
                    OnKeyDown(key);
                }
            }
            lastPressedKeys = pressedKeys;
        }

        public void OnKeyUp(Keys key)
        {
        }
        public void OnKeyDown(Keys key)
        {
            if (key == Keys.Back && name.Length > 0)
            {
                name = name.Remove(name.Length - 1);
            }
            else
            {
                if ((int)key >= 65 && (int)key <= 90 && name.Length < 8)     
                name += key.ToString();
            }
        }
        public string LOGIN_NAME
        {
            get { return f_name; }
            set { f_name = value; }
        }
        public override bool LoadContents()
        {
            font = _contents.Load<SpriteFont>("nFont");
            background = _contents.Load<Texture2D>("loginBackground");
            namebox = _contents.Load<Texture2D>("nameBox");
            return true;
        }
    }
}
