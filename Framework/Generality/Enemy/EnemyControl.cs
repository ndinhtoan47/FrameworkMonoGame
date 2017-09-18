using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Framework.Generality.Bases;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Framework.Generality.Enemy
{
    class EnemyControl: Bases.Object
    {
        protected Texture2D Sprite;
        protected Vector2 position;
        protected Rectangle derution;
        protected float Phase = 0;
        protected float PhaseNumber = 7;

        protected float delayTime = 0.5f;
        protected float TotalDelayTime = 0f;

        protected float RolldelayTime = 2.5f;
        protected float TotalRollDelaytime = 0f;

        protected float ShootdelayTime = 1.25f;
        protected float TotalShootDelaytime = 0f;

        public float velocity = 50;
        protected float Angle = 0;
        protected bool Left, Right, Up, Down, Begin;
        protected Vector2 origin;
        public List<EnemyBullet> Bull= new List<EnemyBullet>();
        protected EnemyBullet Bullet;
       

        public EnemyControl(Vector2 point,Texture2D TankTex, Texture2D BullTex)
        {
            Bullet = new EnemyBullet(BullTex);
            Sprite = TankTex;
            position =point;
            derution = new Rectangle(0,0,32,32);
            Up = false;
            Left = false;
            Right = false;
            Down = false;
            Begin = false;
        }
        protected void UpdataPhase(float deltaTime)
        {

            if (this.TotalDelayTime >= this.delayTime)
            {
                this.Phase++;
                this.TotalDelayTime = 0;
            }
            else
            {
                this.TotalDelayTime += deltaTime;
            }

            if (Phase == this.PhaseNumber)
            {
                //movingPhase = 0;
                Phase = 0;
              
            }
            derution.X = (int)(Phase*32);
        }
        public override bool Init()

        {
            return base.Init();
        }

        public override void LoadContents(ContentManager contents)
        {
            Sprite = contents.Load<Texture2D>("tanktile");
            base.LoadContents(contents);

        }
        public void UpdataMove(float deltaTime)
        {
            Bullet.Update(deltaTime);
            if (TotalRollDelaytime > RolldelayTime)
            {
                Random r = new Random();
                int nextValue = r.Next(0, 4);
                if (nextValue == 0)
                {
                    Angle = 0;
                    Up = true;
                    Left = false;
                    Right = false;
                    Down = false;
                }
                if (nextValue == 1)
                {
                    Angle = 1.59f;
                    Right = true;
                    Down = false;
                    Up = false;
                    Left = false;

                }
                if (nextValue == 2)
                {
                    Angle = 3.15f;
                    Down = true;
                    Up = false;
                    Left = false;
                    Right = false;
                }
                if (nextValue == 3)
                {
                    Angle = 4.71f;
                    Left = true;
                    Down = false;
                    Up = false;

                    Right = false;
                }
                TotalRollDelaytime = 0;
            }
            else
            {
                TotalRollDelaytime += deltaTime;
            }
            if (position.X >= 16 && position.X <= 800-16 && position.Y >= 16 && position.Y <= 600-16)
            {
                if (Up == true)
                {
                    position.Y -= 1 * delayTime;

                }
                if (Down == true)
                {

                    position.Y += 1 * delayTime;
                }
                if (Left == true)
                {
                    position.X -= velocity * deltaTime;
                }
                if (Right == true)
                {
                    position.X += velocity * deltaTime;
                }
            }
            if (position.X < 16)
                position.X = 16;
            if (position.X  > 800 - 16)
                position.X = 800 - 16;
            if (position.Y < 16)
                position.Y = 16;
            if (position.Y  > 600 - 16)
                position.Y = 600 - 16;
        }

        public override void Update(float deltaTime)
        {
            origin.X =16;
            origin.Y = 16;

            this.UpdataMove(delayTime);
            this.UpdataPhase(deltaTime);
            this.updataBullet(deltaTime);
            base.Update(deltaTime);
        }
        public void updataBullet(float deltaTime)
        {
            foreach (EnemyBullet bullet in Bull)
            {
                bullet.BullPoisition += bullet.velocity;
                if (Vector2.Distance(bullet.BullPoisition, position) > 800)
                    bullet.Invisible = false;
            }

            for (int i = 0; i < Bull.Count; i++)
            {
                if (!Bull[i].Invisible)
                {
                    Bull.RemoveAt(i);
                    i--;
                }
            }
            if(TotalShootDelaytime>ShootdelayTime)
            {
                this.Shoot();
                TotalShootDelaytime = 0;
            }
            else
            {
                TotalShootDelaytime += deltaTime;
            }
        }
        public void Shoot()
        {
            Bullet.velocity = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - Angle), -(float)Math.Sin(MathHelper.ToRadians(90) - Angle)) * 5f;
            Bullet.BullPoisition.X = position.X - 5;
            Bullet.BullPoisition.Y = position.Y - 2;
            Bullet.Invisible = true;
            Bull.Add(Bullet);
        }
        public override void Draw(SpriteBatch sp)
        {
            sp.Draw(Sprite, position, derution, Color.Wheat, Angle, origin,1f, SpriteEffects.None, 0f);
            base.Draw(sp);
        }

    }
}
