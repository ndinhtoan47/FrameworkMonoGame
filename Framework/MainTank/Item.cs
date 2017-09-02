using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Framework.Generality.Bases;

namespace Framework.MainTank
{
    class Item : Generality.Bases.Object
    {
        public Texture2D image;
        public Vector2 position;
        public Vector2 origin;

        public float timeIsVisible = 10f;
        public float TotalIsVisibleTime = 0f;

        public bool isVisible;
        public bool Collision;

        public Item()
        {
            image = null;
            isVisible = false;
            setRandomPosition();
        }

        public void LoadContent(ContentManager contents)
        {
            Random rd = new Random();
            int randomValue = rd.Next(0, 2);
            if (randomValue == 0)
                image = contents.Load<Texture2D>("item");
            if (randomValue == 1)
                image = contents.Load<Texture2D>("item1");
            if (randomValue == 2)
                image = contents.Load<Texture2D>("item2");
        }

        public void Update(float deltaTime)
        {
            if (this.TotalIsVisibleTime >= this.timeIsVisible)
            {
                setRandomPosition();
                this.isVisible = false;
                this.TotalIsVisibleTime = 0f;
            }
            else
            {
                if (!Collision)
                {
                    this.isVisible = true;
                    this.TotalIsVisibleTime += deltaTime;
                }
            }
           


        }

        public void setRandomPosition()  //Set Random Position Except Tilemap position
        {
            Random random = new Random();
            this.position.X = random.Next(10, 800);
            this.position.Y = random.Next(10, 400);
        }

        public void Draw(SpriteBatch sp)
        {
            if (isVisible)
            {
                sp.Draw(image, position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0);
            }
        }

        public Box2D boxItem()
        {
            Box2D boxItem;
            return boxItem = new Box2D(this.position.X, this.position.Y, 0, 0, this.image.Width, this.image.Height);
        }

    }
}
