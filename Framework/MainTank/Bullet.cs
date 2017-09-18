
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Framework.Generality.Bases;

namespace Framework.MainTank
{
    public class Bullet : Object
    {
        public Texture2D image;
        //public float rotation;
        public Vector2 position;
        public Vector2 origin;
        public Vector2 velocity;

        //public KeyboardState currentKey;
        //public KeyboardState previousKey;

        //public Vector2 direction;
        //public float rotationVelocity = 3f;
        //public float linearVelocity = 4f;

        //public float lifeSpan = 0f;

        public bool isVisible;

        public Bullet(Texture2D _image) : base()
        {
            image = _image;
            isVisible = false;
            //origin = new Vector2(image.Width / 2, image.Height / 2);
        }


        public override void Draw(SpriteBatch sp)
        {
            sp.Draw(image, position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0);
        }
    }
}
