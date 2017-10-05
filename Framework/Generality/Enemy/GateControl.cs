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
using Framework.Generality.ColisionDetection;


namespace Framework.Generality.Enemy
{
    class GateControl
    {
        protected Texture2D Gatesprite;
        protected Rectangle Rectrag;
        protected Rectangle DesRec;
        public Vector2 poisiton;
        List<Enemy> ManegerMonster = new List<Enemy>();
        protected ContentManager content;
        protected float delaytime = 0.1f;
        protected float totaledelaytiem = 0;
        protected float auto = 0;
        protected float phase = 0f;
        protected float totalPhase = 13f;
        protected int cout;
        protected float Seri = 213f;
        protected Collision col;
        protected Enemy Tank;
        protected float delapađTime = 5f;
        protected float TotalAddTime = 0f;
        protected bool Open = false;
        public GateControl(ContentManager _content)
        {
            content = _content;
            Rectrag = new Rectangle(0, 0, 74, 58);
            DesRec = new Rectangle(0, 0, 48, 48);
            DesRec.X = 100;
            DesRec.Y = 100;
            Open = false;
            col = new Collision();
        }
  
        public void UpdataPhase(float DeltaTime)
        {
            if (totaledelaytiem > delaytime)
            {
                this.phase++;
                this.totaledelaytiem = 0;
                this.Seri++;
            }
            else
            {
                this.totaledelaytiem += DeltaTime;
            }
            if (phase == totalPhase)
            {
                cout++;
                phase = 0;
                Seri = 213;
                Open = false;
            }
        }
        private void UpdateGate(float DeltaTime)
        {
            if (TotalAddTime > delapađTime)
            {

                Open = true;
                TotalAddTime = 0;
                Random r = new Random();
                int nextValue = r.Next(0, 3);
                if (nextValue == 0)
                {
                    poisiton.X = 100;
                    poisiton.Y = 200;
                }
                if (nextValue == 1)
                {
                    poisiton.X = 250;
                    poisiton.Y = 250;
                }
                if (nextValue == 2)
                {
                    poisiton.X = 600;
                    poisiton.Y = 400;
                }
                if (nextValue == 3)
                {
                    poisiton.X = 450;
                    poisiton.Y = 300;
                }
                DesRec.X = (int)poisiton.X;
                DesRec.Y = (int)poisiton.Y;
                ManegerMonster.Add(Tank = new Enemy(poisiton, content.Load<Texture2D>("TankTile1"), content.Load<Texture2D>("Bullet3")));
                
            }
            else
            {
                this.TotalAddTime += DeltaTime;

            }
            if (Open == true)

            {
                this.UpdataPhase(DeltaTime);


            }
          
            
        }
        public void Updata(float DeltaTime)
        {
            foreach (Enemy Monster in ManegerMonster)
            {
                Monster.Update(DeltaTime);
            }
            for (int i = 0; i < cout; i++)
            {
                for (int j = i+1; j < cout; j++)
                {
                  bool a=  col.Intersect(ManegerMonster[i].BOX2D, ManegerMonster[j].BOX2D);
                    if(a== true)
                    {
                        ManegerMonster[j].CheckCollision(a, DeltaTime);
                        ManegerMonster[i].CheckCollision(a, DeltaTime);
                    }
                }
            }
            if (cout < 5)
            { UpdateGate(DeltaTime); }
            //if (auto > 20)
            //{
            //    ManegerMonster.RemoveAt(0);
            //    cout--;
            //    auto = 0;
            //}

            //a += 1 * DeltaTime;
        }
        public void Draw(SpriteBatch sp)
        {
            foreach (Enemy Monster in ManegerMonster)
            {
                Monster.Draw(sp);
            }
                Gatesprite = content.Load<Texture2D>("shape" + Seri);
            if (Open == true&& cout < 5)
                sp.Draw(Gatesprite,DesRec, Rectrag, Color.Wheat);
        }
    }
}
