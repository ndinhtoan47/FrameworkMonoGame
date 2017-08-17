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
        protected float RolldelayTime = 50f;
        protected float TotalRollDelaytime = 0f;
        protected float Angle = 0;
        protected bool Left, Right, Up, Down;
        protected Vector2 origin;
       

        public EnemyControl()
        {

            position = new Vector2(100,100);
            derution = new Rectangle(0,0,32,32);
            Up = false;
            Left = false;
            Right = false;
            Down = false;



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
            Sprite = contents.Load<Texture2D>("TankTile1");
            base.LoadContents(contents);

        }
        public void UpdataMove(float deltaTime)
        {
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
            if (position.X >= 16 && position.X <= 800-16 && position.Y >= 16 && position.Y <= 480-16)
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
                    position.X -= 1 * delayTime;
                }
                if (Right == true)
                {
                    position.X += 1 * delayTime;
                }
            }
            if (position.X <= 16)
                position.X = 16;
        }

        public override void Update(float deltaTime)

        {
            origin.X =16;
            origin.Y = 16;



            this.UpdataMove(delayTime);
            this.UpdataPhase(deltaTime);
            base.Update(deltaTime);
        }
        public override void Draw(SpriteBatch sp)
        {



            sp.Draw(Sprite, position, derution, Color.Wheat, Angle, origin,1f, SpriteEffects.None, 0f);
            


           
            base.Draw(sp);
        }

    }
}
