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
using Framework.MainTank;
using Framework.Generality.Enemy;
using Framework.Generality.ColisionDetection;
using Framework.Generality.Managers;
using Framework.Generality.Bases.Camera2D;

namespace Framework
{
    class GameScene : Scene
    {
        protected ContentManager content;
        protected Tank nTank;
        protected Enemy nEnemy;
        protected Item nItem;
        protected List<Item> _nItem;
        Collision nCollision;
        protected float totalDelaytimeVisible = 0f;
        protected float delayTimeVisible = 5f;
        protected float totalDelaytimeInVisible = 0f;
        protected float delayTimeInvisible = 11f;
        protected float totalTimeEffect = 0f;
        public GameScene(ContentManager _content) : base()
        {
            content = _content;
            nTank = new Tank();
            //nEnemy = new Enemy();
            _nItem = new List<Item>();
            nCollision = new Collision();
            _name = "gameScene";
        }
        public override bool Init()
        {
            return base.Init();
        }
        public override void Shutdown()
        {
            base.Shutdown();
        }

        public void LoadContents(ContentManager content)
        {
            nTank.LoadContents(content);
            nEnemy.LoadContents(content);
        }
        public override GameManager.GameState Update(float deltaTime)
        {
            nTank.Update(deltaTime);
            nEnemy.Update(deltaTime);
            itemUpdate(deltaTime, Game1._content);
            collisionUpdate(deltaTime);
            return base.Update(deltaTime);
        }
        public void itemUpdate(float deltaTime, ContentManager content)
        {
            spawnItem(deltaTime);
            //if(_nItem.Count > 0)
            //{
            //    foreach(Item i in _nItem)
            //    {
            //        i.Update(deltaTime);
            //    }
            //}
            //remove item
            if (totalTimeEffect >= 8f)
            {
                _nItem[0].Update(deltaTime);
            }
            else
            {
                totalTimeEffect += deltaTime;
            }

            if (totalDelaytimeInVisible >= delayTimeInvisible)
            {
                _nItem.RemoveAt(0);
                totalDelaytimeInVisible = 0;
            }
            else
            {
                totalDelaytimeInVisible += deltaTime;
            }


            

            
        }
        public void spawnItem(float deltaTime)
        {
            if (_nItem.Count() < 3)
            {
                _nItem.Add(nItem = new Item(randomImage()));
            }
        }
        public void removeItem(float deltaTime)
        {

        }
        public Texture2D randomImage()
        {
            Texture2D image;
            Random rd = new Random();
            int randomValue = rd.Next(0, 2);
            if (randomValue == 0)
                return image = content.Load<Texture2D>("item");
            if (randomValue == 1)
                return image = content.Load<Texture2D>("item1");
            if (randomValue == 2)
                return image = content.Load<Texture2D>("item2");
            else return null;
        }

        public void collisionUpdate(float deltaTime)
        {
            
        }        

        public override void Draw(SpriteBatch sp)
        {
            nTank.Draw(sp);
            nEnemy.Draw(sp);
            foreach(Item i in _nItem)
            {
                i.Draw(sp);
            }
            base.Draw(sp);
        }

        public Vector2 tankPos
        {
            get { return this.nTank.POSITION; }
        }


        
        
    }
}
