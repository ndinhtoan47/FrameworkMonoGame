
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Generality.Bases.Tiles
{
    public class MetalBox:Tile
    {
        private Texture2D _metalDestroyed;
        public MetalBox(int id, Vector2 position, int size)
            :base(id,position,size)
        {
            _metalDestroyed = null;
        }
        public override bool Init()
        {
            _box.x = _position.X;
            _box.y = _position.Y;
            _box.width = _size;
            _box.height = _size;
            _box.vx = 0;
            _box.vy = 0;
            _hp = 5;
            return base.Init();
        }
        public override void LoadContents(ContentManager contents)
        {
            if (_tileId != 0 && _tileId != 6)
            {
                _texture = contents.Load<Texture2D>(@"Tiles\" + _tileId.ToString());
                _metalDestroyed = contents.Load<Texture2D>(@"Tiles\" + _tileId.ToString() + "1");
            }
            base.Init();
        }
        public override void Draw(SpriteBatch sp)
        {
            if (_texture != null && _hp >= 2)
            {
                Rectangle rect = new Rectangle((int)_box.x, (int)_box.y, _box.width, _box.height);
                sp.Draw(_texture, rect, Color.White);
            }
            if(_metalDestroyed != null && _hp < 2 && _hp > 0)
            {
                Rectangle rect = new Rectangle((int)_box.x, (int)_box.y, _box.width, _box.height);
                sp.Draw(_metalDestroyed, rect, Color.White);
            }
            base.Draw(sp);
        }
        public override void Update(float deltaTime)
        {
            _box.x = _position.X;
            _box.y = _position.Y;
            base.Update(deltaTime);
        }
        public override void ReceiveDamage()
        {
            _hp--;
        }
    }
}
