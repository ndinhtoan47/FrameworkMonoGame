

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Generality.Bases.Tiles
{
    public class EmptyTile : Tile
    {
        public EmptyTile(int id,Vector2 position,int size)
            :base(id,position,size)
        {

        }
        public override bool Init()
        {
            _box.x = _position.X;
            _box.y = _position.Y;
            _box.width = _size;
            _box.height = _size;
            _box.vx = 0;
            _box.vy = 0;
            return base.Init();
        }
        public override void LoadContents(ContentManager contents)
        {
            if (_tileId != 0 && _tileId != 6)
                _texture = contents.Load<Texture2D>(@"Tiles\" + _tileId.ToString());
            base.Init();
        }
        public override void Draw(SpriteBatch sp)
        {
            if (_texture != null)
            {
                Rectangle rect = new Rectangle((int)_box.x, (int)_box.y, _box.width, _box.height);
                sp.Draw(_texture, rect, Color.White);
            }
            base.Draw(sp);
        }
        public override void Update(float deltaTime)
        {
            _box.x = _position.X;
            _box.y = _position.Y;
            base.Update(deltaTime);
        }
        public override void ReceiveDamage() { }
    }
}
