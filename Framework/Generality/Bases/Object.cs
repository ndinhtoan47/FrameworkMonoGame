using Framework.Generality.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Framework.Generality.Bases
{
    public class Object
    {
        public enum Essential
        {
            NONE,
        }
        // local of the object
        protected Vector2 _position;
        // only one id with one object
        protected ulong _id;
        // box used to collision detection
        protected Box2D _box;
        public Object()
        {
            _position = Vector2.Zero;
            _id = GameManager.GetId();
            _box = new Box2D();
            GameManager.AddObject(this);
        }

        public virtual bool Init() { return true; }
        public virtual void LoadContents(ContentManager contents) { }
        public virtual void Draw(SpriteBatch sp) { }
        public virtual void Update(float deltaTime, ContentManager contents) { }
        
        // properties
        public Vector2 POSITION
        {
            get { return _position; }
            set { _position = value; }
        }
        public ulong ID
        {
            get { return _id; }
            private set { _id = value; }
        }
        public Box2D BOX2D
        {
            get { return _box; }
            protected set { _box = value; }
        }
    }
}
