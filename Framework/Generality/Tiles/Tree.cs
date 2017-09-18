using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Generality.Tiles
{
    public class Tree : Tile
    {
        public Tree(Vector2 position, int size)
            : base(2,position,size)
        {
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
            return base.Init();
        }
        public override void LoadContents(ContentManager contents)
        {
            if (_tileId != 0)
                _texture = contents.Load<Texture2D>(@"Tiles\" + _tileId.ToString());
            base.LoadContents(contents);
        }
        public override void Draw(SpriteBatch sp)
        {
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
