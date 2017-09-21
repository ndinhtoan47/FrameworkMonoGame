

using Framework.Generality.Managers;
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

namespace Framework.Generality.Bases.GameScenes
{
    public class PlayScene : Scene
    {
        public PlayScene(ContentManager contents) :
            base(Constants.SCENE_PLAY,contents)
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
            sp.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, null);

            sp.End();
        }
        public override GameManager.GameState Update(float deltaTime)
        {
            return GameManager.GameState.None;
        }
        public override bool LoadContents() { return true; }


    }
}
