using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Framework.Generality.Bases;
using Framework.Generality.InputControl;

namespace Framework.MainTank
{
    class Item : Generality.Bases.Object
    {
        public Texture2D image;
        public Vector2 origin;
        public Vector2 position;
        //public float timeIsVisible = 10f;
        //public float TotalIsVisibleTime = 0f;
        public bool isCollision;
        //public bool isVisible;
        //public bool Collision;
        public Color color = new Color(225, 225, 225, 225);
        protected bool updateColor = false;
        protected float totalTime = 0.0f;
        protected Random nRandom;
        public Item(Texture2D _image) : base()
        {
            image = _image;
            setRandomPosition();
            isCollision = false;
            nRandom=new Random();
            //isVisible = false;
        }

        public override void LoadContents(ContentManager contents)
        {
            image = contents.Load<Texture2D>(itemString());
            //Random rd = new Random();
            //int randomValue = rd.Next(0, 2);
            //if (randomValue == 0)
            //    image = contents.Load<Texture2D>("item");
            //if (randomValue == 1)
            //    image = contents.Load<Texture2D>("item1");
            //if (randomValue == 2)
            //    image = contents.Load<Texture2D>("item2");
        }
        public string itemString()
        {
            int randomValue = nRandom.Next(0, 2);
            if (randomValue == 0)
                return "item";
            if (randomValue == 1)
                return "item1";
            if (randomValue == 2)
                return "item2";
            else return null;
        }


        public override void Update(float deltaTime)
        {
            //setRandomPosition();

            ///// test color down
            if (updateColor)
                DownColor(deltaTime);
            else
                UpColor(deltaTime);

            if (totalTime >= 0.3)
            {
                updateColor = !updateColor;
                totalTime = 0;
            }
            totalTime += deltaTime;


        }

        public void setRandomPosition()  //Set Random Position Except Tilemap position
        {
            Random random = new Random();
            this.position.X = random.Next(10, 800);
            this.position.Y = random.Next(10, 400);
        }
        public void itemEffect()
        {
            color.A -= 3;
        }

        public override void Draw(SpriteBatch sp)
        {

            sp.Draw(image, position, null, this.color, 0f, origin, 1f, SpriteEffects.None, 0);
        }

        public Box2D boxItem()
        {
            Box2D boxItem;
            return boxItem = new Box2D(this.position.X, this.position.Y, 0, 0, this.image.Width, this.image.Height);
        }

        protected void UpColor(float deltaTime)
        {
            Color temp = new Color(color.R - 100, color.G - 100, color.B -100, color.A - 100);
            color = temp;

        }
        protected void DownColor(float deltaTime)
        {

            Color temp = new Color(color.R +100 , color.G +100, color.B +100, color.A + 100);
            color = temp;

        }
    }
}
