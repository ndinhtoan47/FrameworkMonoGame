using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Framework.Generality.Bases;
using Framework.Generality.InputControl;

namespace Framework.MainTank
{
    class Tank : Generality.Bases.Object
    {
        protected Vector2 tankPosition;
        //protected Vector2 tankVelocity;
        protected ulong id;
        protected Box2D box;
        protected Texture2D tankImage;
        protected Rectangle tankRec;

        public float rotation;
        public Vector2 _origin;
        public float rotationVelocity = 3f;
        public float linearVelocity = 3f;


        public List<Bullet> bullets = new List<Bullet>();
        public Bullet nBullet;
        KeyboardState preKey;

        //Test
        
        
        public Tank()
        {
            tankImage = null;
            tankPosition = new Vector2(200, 250);
            tankRec = new Rectangle();
        }

        public override bool Init() { return true; }

        public override void LoadContents(ContentManager contents)
        {
            tankImage = contents.Load<Texture2D>("tankdemo");
            tankRec = new Rectangle((int)tankPosition.X, (int)tankPosition.Y, tankImage.Width, tankImage.Height);
            //tankPosition = new Vector2(tankImage.Width / 2f, tankImage.Height / 2f);   
        }
        public override void Draw(SpriteBatch sp)
        {
            _origin = new Vector2(tankImage.Width / 2f, tankImage.Height / 2f);
            foreach (Bullet bullet in bullets)
                bullet.Draw(sp);
            sp.Draw(tankImage, tankPosition, null, Color.White, rotation, _origin, 1, SpriteEffects.None, 0);
        }
        public override void Update(float deltaTime, ContentManager contents)
        {
            ControllerUpdate(deltaTime, contents);
        }

        public void ControllerUpdate(float deltaTime, ContentManager contents)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                rotation -= MathHelper.ToRadians(rotationVelocity);
                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                rotation += MathHelper.ToRadians(rotationVelocity);

            var direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                tankPosition += direction * linearVelocity;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                tankPosition -= direction * linearVelocity;


            if (Keyboard.GetState().IsKeyDown(Keys.Space) && preKey.IsKeyUp(Keys.Space))
                Shoot(contents);

            preKey = Keyboard.GetState();
            UpdateBullets(deltaTime);
                
        }

        public void UpdateBullets(float deltaTime)
        {
            foreach(Bullet bullet in bullets)
            {
                bullet.position += bullet.velocity;
                if (Vector2.Distance(bullet.position, tankPosition) > 400) 
                    bullet.isVisible = false;
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }

        }

        

        public void Shoot(ContentManager contents)
        {
            nBullet = new Bullet(contents.Load<Texture2D>("_bullet"));
            nBullet.velocity = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation)) * 5f; //+ tankVelocity;
            nBullet.position = tankPosition + nBullet.velocity * 5;
            nBullet.isVisible = true;

            if (bullets.Count() < 30)
                bullets.Add(nBullet);
        }

        public void Death()
        {
            int a = 0;
        }

        public void Restart()
        {

        }
    }
}
