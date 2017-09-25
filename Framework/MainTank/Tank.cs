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
using Framework.Generality.Sounds;

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
        protected Color color = new Color(225, 225, 225, 225);
        protected bool hpUp, powerUp = true, amor;
        protected string tankState = "";
        protected float TotaldelayTimeEffect = 0f;
        protected float delayTimeEffect = 10f;
        protected int Hp = 3;
        public bool isCollision;

        protected float rotation;
        protected Vector2 _origin;
        protected float rotationVelocity = 3f;
        protected float linearVelocity = 100f;

        protected SEffect sEff;
        protected List<Bullet> bullets = new List<Bullet>();
        protected Bullet nBullet;
        //protected Item nItem;
        KeyboardState preKey;
        //Test
        Collision nCollision;

        //Enemy nEnemy;

        public Tank()
        {
            tankImage = null;
            tankPosition = new Vector2(100, 250);
            tankRec = new Rectangle();
            sEff = new SEffect();
            isCollision = false;

            //nItem = new Item();

            //Demo
            nCollision = new Collision();
            //nEnemy = new Enemy();
        }

        public override bool Init() { return base.Init(); }

        public override void LoadContents(ContentManager contents)
        {
            tankImage = contents.Load<Texture2D>("tank");
            tankRec = new Rectangle((int)tankPosition.X, (int)tankPosition.Y, tankImage.Width, tankImage.Height);
            sEff.LoadContents(contents, "s_tank_1");
        }
        public override void Draw(SpriteBatch sp)
        {
            _origin = new Vector2(tankImage.Width / 2f, tankImage.Height / 2f);
            foreach (Bullet bullet in bullets)
                bullet.Draw(sp);
            //nItem.Draw(sp);
            sp.Draw(tankImage, tankPosition, null, color, rotation, _origin, 1, SpriteEffects.None, 0);

            //demo
            //if (_Collision() == false) 
            //{
            //    nEnemy.Draw(sp);

            //}
        }
        public override void Update(float deltaTime)
        {
            _position = this.tankPosition;
            ControllerUpdate(deltaTime, Game1._content);
            tankEffect(deltaTime);
            _box = new Box2D(this.tankPosition.X, this.tankPosition.Y, this.linearVelocity, this.linearVelocity, this.tankImage.Width, this.tankImage.Height);
            UpdateHp(deltaTime);
        }
        public void tankEffect(float deltaTime)
        {
            if (hpUp)
            {
                Hp += 1;
            }
            if (powerUp)
            {
                color.G = 0;
            }
            if (amor)
            {
                color.A = 0;
            }
            if (color.A == 0)
            {
                if (TotaldelayTimeEffect >= delayTimeEffect)
                {
                    amor = false;
                    color.A = 225;
                    TotaldelayTimeEffect = 0f;
                }
                else
                {
                    TotaldelayTimeEffect += deltaTime;
                }
            }
            if (color.G == 0)
            {
                if (TotaldelayTimeEffect >= delayTimeEffect)
                {
                    powerUp = false;
                    color.G = 225;
                    TotaldelayTimeEffect = 0f;
                }
                else
                {
                    TotaldelayTimeEffect += deltaTime;
                }
            }
        }

        public void ControllerUpdate(float deltaTime, ContentManager contents)
        {
            var direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                rotation = 4.71f;
                tankPosition.X -= linearVelocity * deltaTime;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                rotation = 1.59f;
                tankPosition.X +=  linearVelocity * deltaTime;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                tankPosition.Y -=linearVelocity * deltaTime;
                rotation = 0f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S)) 
            {
                tankPosition.Y += linearVelocity*deltaTime;
                rotation = 3.15f;
            }



            if (Keyboard.GetState().IsKeyDown(Keys.Space) && preKey.IsKeyUp(Keys.Space))
            {
                sEff.Play();
                Shoot(contents);
            }

            //test
            if (Keyboard.GetState().IsKeyDown(Keys.T) && preKey.IsKeyUp(Keys.T))
                isCollision = true;

            preKey = Keyboard.GetState();
            UpdateBullets(deltaTime);

        }

        public void UpdateBullets(float deltaTime)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.position += bullet.velocity;
                if (Vector2.Distance(bullet.position, tankPosition) > 300)
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

        public string spriteTank()
        {
            string _string;
            if (powerUp)
                return _string = "_bullet";
            else return _string = "bullet";

        }


        public void Shoot(ContentManager contents)
        {
            nBullet = new Bullet(contents.Load<Texture2D>(spriteTank()));
            nBullet.velocity = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation)) * 5f; //+ tankVelocity;
            nBullet.position = tankPosition + nBullet.velocity * 5;
            nBullet.isVisible = true;

            if (bullets.Count() < 20)
                bullets.Add(nBullet);
        }
        public Vector2 bulletVelocity()
        {
            return nBullet.velocity;
        }

        
        public Box2D boxBullet()
        {
            return _boxBullet;
        }

        public string TANKSTATE
        {
            get
            {
                if (hpUp)
                    return "HP_UP";
                if (powerUp)
                    return "POWER_UP";
                if (amor)
                    return "AMOR_BUFF";
                else return null;
            }
            set { }
        }

        public void UpdateHp(float deltaTime)
        {
            if (isCollision)
                Hp -= 1;
            if (Hp >= 3)
                Hp = 3;
        }
        //demo
        //public Box2D boxEnemy()
        //{
        //    Box2D nBox = new Box2D();
        //    nBox = new Box2D(nEnemy.POSITION.X, nEnemy.POSITION.Y, 0, 0, nEnemy.Sprite.Width, nEnemy.Sprite.Height);
        //    return nBox;
        //}

        //public void Collision()
        //{
        //    bool collision;
        //    collision = nCollision.Intersect(boxTank(), nItem.boxItem());
        //    if(collision)
        //    {
        //        nItem.isVisible = false;
        //    }
        //}


    }
}