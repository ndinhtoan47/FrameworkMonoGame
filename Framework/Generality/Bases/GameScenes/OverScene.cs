using Framework.Generality.Managers;
using Framework.Generality.OffSets;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Generality.Bases.GameScenes
{
    public class OverScene : Scene
    {
        public OverScene(ContentManager contents) :
            base(Constants.SCENE_OVER, contents)
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
        public override void Draw(SpriteBatch sp) { }
        public override GameManager.GameState Update(float deltaTime)
        {
            return GameManager.GameState.None;
        }
        public override bool LoadContents() { return true; }
    }
}
