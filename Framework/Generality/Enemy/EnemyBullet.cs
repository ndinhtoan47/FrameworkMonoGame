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
    class EnemyBullet:Bases.Object
    {
        protected Texture2D BulletSprite;
        public Vector2 BullPoisition;
        protected Rectangle Suorbull;
        protected Rectangle RecBull;
        protected Vector2 Origin;
       public  Vector2 velocity ;
        public bool Invisible = true;

        public EnemyBullet() 
        {
           
            Suorbull = new Rectangle(0, 0, 104, 103);
            RecBull = new Rectangle(0, 0, 10, 10);

            Origin = new Vector2(15, 15);
            
        }
        public override bool Init()
        {
            return base.Init();
        }
        public override void LoadContents(ContentManager contents)
        {
            BulletSprite = contents.Load<Texture2D>("Bullet3");
            base.LoadContents(contents);
        }
      
        public override void Update(float deltaTime)
        {
            RecBull.X = (int)BullPoisition.X;

            RecBull.Y = (int)BullPoisition.Y;


         
            base.Update(deltaTime);
        }
        public override void Draw(SpriteBatch sp)
        {
            sp.Draw(BulletSprite, RecBull,  Suorbull, Color.Wheat);
            base.Draw(sp);
        }

    }
}
