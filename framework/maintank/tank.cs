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
using Framework.Generality.ColisionDetection;
using Framework.Generality.Enemy;

namespace Framework.MainTank
{
    class Tank : Generality.Bases.Object
    {
        protected Vector2 tankPosition;
        //protected Vector2 tankVelocity;
        protected ulong id;
        protected Box2D _boxTank;
        protected Box2D _boxBullet;
        protected Texture2D tankImage;
        protected Rectangle tankRec;

        protected float rotation;
        protected Vector2 _origin;
        protected float rotationVelocity = 3f;
        protected float linearVelocity = 1.5f;


        protected List<Bullet> bullets = new List<Bullet>();
        protected Bullet nBullet;
        protected Item nItem;
        KeyboardState preKey;

        protected bool powerUp;
        //Test
        Collision nCollision;

        //Enemy nEnemy;
        
        public Tank()
        {
            tankImage = null;
            tankPosition = new Vector2(200, 250);
            tankRec = new Rectangle();
            nItem = new Item();

            //Demo
            nCollision = new Collision();
            //nEnemy = new Enemy();
        }

        public override bool Init() { return base.Init(); }

        public override void LoadContents(ContentManager contents)
        {
            tankImage = contents.Load<Texture2D>("tank");
            tankRec = new Rectangle((int)tankPosition.X, (int)tankPosition.Y, tankImage.Width, tankImage.Height);
            nItem.LoadContent(contents);
            //tankPosition = new Vector2(tankImage.Width / 2f, tankImage.Height / 2f); 
            //Demo
            //nEnemy.LoadContents(contents);
        }
        public override void Draw(SpriteBatch sp)
        {
            _origin = new Vector2(tankImage.Width / 2f, tankImage.Height / 2f);
            foreach (Bullet bullet in bullets)
                bullet.Draw(sp);
            nItem.Draw(sp);
            sp.Draw(tankImage, tankPosition, null, Color.White, rotation, _origin, 1, SpriteEffects.None, 0);

            //demo
            //if (_Collision() == false) 
            //{
            //    nEnemy.Draw(sp);

            //}
        }
        public override void Update(float deltaTime)
        {
            ControllerUpdate(deltaTime, Game1._content);
            nItem.Update(deltaTime);
            Collision();
            _position = tankPosition;
            //demo
            //nEnemy.Update(deltaTime);
        }

        public void ControllerUpdate(float deltaTime, ContentManager contents)
        {
            var direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //rotation -= MathHelper.ToRadians(rotationVelocity);
                rotation = 4.71f;
                tankPosition += direction * linearVelocity;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D)) 
            {
                //rotation += MathHelper.ToRadians(rotationVelocity);
                rotation = 1.59f;
                tankPosition += direction * linearVelocity;
            }



            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                tankPosition += direction * linearVelocity;
                rotation = 0f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                tankPosition += direction * linearVelocity;
                rotation = 3.15f;
            }

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
            nBullet = new Bullet(contents.Load<Texture2D>("bullet"));
            nBullet.velocity = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation)) * 5f; //+ tankVelocity;
            nBullet.position = tankPosition + nBullet.velocity * 5;
            nBullet.isVisible = true;

            _boxBullet = new Box2D(nBullet.position.X, nBullet.position.Y, nBullet.velocity.X, nBullet.velocity.Y, nBullet.image.Width, nBullet.image.Height);

            if (bullets.Count() < 20)
                bullets.Add(nBullet);
        }
        public Vector2 bulletVelocity()
        {
            return nBullet.velocity;
        }

        public Box2D boxTank()
        {
            return _boxTank = new Box2D(this.tankPosition.X, this.tankPosition.Y, this.linearVelocity, this.linearVelocity, this.tankImage.Width, this.tankImage.Height);
        }
        public Box2D boxBullet()
        {
            return _boxBullet;
        }
        
        //demo
        //public Box2D boxEnemy()
        //{
        //    Box2D nBox = new Box2D();
        //    nBox = new Box2D(nEnemy.POSITION.X, nEnemy.POSITION.Y, 0, 0, nEnemy.Sprite.Width, nEnemy.Sprite.Height);
        //    return nBox;
        //}

        public void Collision()
        {
            bool collision;
            collision = nCollision.Intersect(boxTank(), nItem.boxItem());
            if(collision)
            {
                nItem.isVisible = false;
            }
        }
   

    }
}
