using Framework.Generality.Managers;
using Framework.Generality.OffSets;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Framework.Generality.Bases.GameScenes
{
    public class LoginScene : Scene
    {
        protected Texture2D BG;
        protected Rectangle rec1;
        ContentManager _content;
        public LoginScene(ContentManager contents) :
            base(Constants.SCENE_LOGIN, contents)
        {
            _content = contents;
            rec1 = new Rectangle(0, 0, 800, 600);
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
            sp.Draw(BG = _contents.Load<Texture2D>("BGLogin"), rec1, Color.Wheat);
        }
        public override GameManager.GameState Update(float deltaTime)
        {
            return GameManager.GameState.None;
        }
        public override bool LoadContents()
        {
            BG = _contents.Load<Texture2D>("BGLogin");
            return true;
        }
    }
}
