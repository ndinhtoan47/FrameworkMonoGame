using Framework.Generality.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Generality
{
    public class Tile : Object
    {
        /// <summary>
        /// 0: nothing
        /// 1: wood box
        /// 2: tree
        /// 3: wall
        /// 4: water
        /// 5: metal box
        /// 51: metal box is detroyed
        /// 6: empty box
        /// </summary>
        protected int _tileId;
        protected Texture2D _texture;
        protected int _size;
        protected int _hp;
        protected Color _color;

        public Tile(int id, Vector2 position, int size)
            : base()
        {
            _tileId = id;
            _position = position;
            _texture = null;
            _size = size;
            _hp = 1;
            _color = new Color(255, 255, 255, 255);
            Init();
        }

        public int GetTileId()
        {
            return _tileId;
        }
        public int GetHP()
        {
            return _hp;
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
            base.LoadContents(contents);
        }
        public override void Draw(SpriteBatch sp)
        {
            if (_texture != null && _hp > 0)
            {
                Rectangle rect = new Rectangle((int)_box.x, (int)_box.y, _box.width, _box.height);
                sp.Draw(_texture, rect,_color);
            }
            base.Draw(sp);
        }
        public override void Update(float deltaTime)
        {
            _box.x = _position.X;
            _box.y = _position.Y;
            base.Update(deltaTime);
        }
        public virtual void ReceiveDamage() { }
    }
}
