using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Framework.Generality.Tiles
{
    public class MetalBox : Tile
    {
        protected Texture2D _destroyedTile;
        protected Texture2D _normalTile;
        public MetalBox(Vector2 position, int size)
            : base(3,position,size)
        {
            _destroyedTile = null;
            _normalTile = null;
            Init();
        }

        public override bool Init()
        {
            _box.x = _position.X;
            _box.y = _position.Y;
            _box.width = _size;
            _box.height = _size;
            _box.vx = 0;
            _box.vy = 0;
            _hp = 3;
            return base.Init();
        }
        public override void LoadContents(ContentManager contents)
        {
            if (_tileId != 0)
                _texture = contents.Load<Texture2D>(@"Tiles\" + _tileId.ToString());
            _destroyedTile = contents.Load<Texture2D>(@"Tiles\" + _tileId.ToString() + "1");
            _normalTile = _texture;
            base.LoadContents(contents);
        }
        public override void Draw(SpriteBatch sp)
        {
            if(_hp < 2)
            {
                _texture = _destroyedTile;
            }
            else
            {
                _texture = _normalTile;
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
