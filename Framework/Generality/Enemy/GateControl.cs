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
    class GateControl
    {
        protected Texture2D Gatesprite;
        protected Rectangle Rectrag;
        protected Rectangle DesRec;
        public Vector2 poisiton;
        List<Enemy> ManegerMonster = new List<Enemy>();
        protected ContentManager content;
        protected float delaytime = 0.2f;
        protected float totaledelaytiem = 0;

        protected float phase = 0f;
        protected float totalPhase = 11;

        protected float Seri = 213f;

        protected Enemy Tank;
        protected float delapađTime = 10f;
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
           
        }
        public void Int()
        {
            Tank = new Enemy(poisiton);
        }
        public void Load(ContentManager _content)
        {
            Tank.LoadContents(_content);
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

                phase = 0;
                Seri = 213;
                Open = false;
            }
        }
        public void Updata(float DeltaTime)
        {
           if(ManegerMonster.Count<30)
            {
                ManegerMonster.Add(Tank);
            }
            if (TotalAddTime > delapađTime)
            {

                Open = true;
                TotalAddTime = 0;
                Random r = new Random();
                int nextValueX = r.Next(0, 750);
                int nextvalueY = r.Next(0, 550);
                poisiton.X = nextValueX;
                poisiton.Y = nextvalueY;
              
                DesRec.X = (int)poisiton.X + 24;
                DesRec.Y = (int)poisiton.Y+24;
                

            }
            else
            {
                this.TotalAddTime += DeltaTime;
                
            }
            if(Open== true)

            {
                this.UpdataPhase(DeltaTime);
               

            }
          
           


        }
        public void Draw(SpriteBatch sp)
        {
            foreach (Enemy Monster in ManegerMonster)
            {
                Tank.Draw(sp);
            }
                Gatesprite = content.Load<Texture2D>("shape" + Seri);
            if (Open == true)
                sp.Draw(Gatesprite,DesRec, Rectrag, Color.Wheat);
        }
    }
}
