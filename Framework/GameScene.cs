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
        //test
        protected float delayTime = 0f;
        protected Texture2D hpBar;
        protected int healthNum = 3;
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
            hpBar = content.Load<Texture2D>("hpBar");
            //nEnemy.LoadContents(content);
        }
        public override GameManager.GameState Update(float deltaTime)
        {
            nTank.Update(deltaTime);
            //nEnemy.Update(deltaTime);
            itemUpdate(deltaTime, Game1._content);
            UpdateBar(deltaTime);
            return base.Update(deltaTime);
        }
        public void itemUpdate(float deltaTime, ContentManager content)
        {
            if (delayTime >= 5f)
            {
                if (_nItem.Count() < 3)
                {
                    _nItem.Add(nItem = new Item(randomImage()));
                }
                delayTime = 0f;
            }
            else
            {
                delayTime += deltaTime;
            }
        }
        public void spawnItem(float deltaTime)
        {
            
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
        public void UpdateBar(float deltaTime)
        {
            if (nTank.isCollision == true) 
            {
                healthNum -= 1;
                nTank.isCollision = false;
            }
            if (healthNum <= 0)
                healthNum = 0;
        }
        public void hpDraw(SpriteBatch sp)
        {
            if (healthNum == 3)
                sp.Draw(hpBar, new Rectangle(0, 0, hpBar.Width, hpBar.Height), Color.White);
            if (healthNum == 2)
                sp.Draw(hpBar, new Rectangle(0, 0, hpBar.Width - 10, hpBar.Height), Color.White);
            if (healthNum == 1)
                sp.Draw(hpBar, new Rectangle(0, 0, hpBar.Width - 30, hpBar.Height), Color.White);
        }

        public override void Draw(SpriteBatch sp)
        {
            nTank.Draw(sp);
            //nEnemy.Draw(sp);
            foreach(Item i in _nItem)
            {
                i.Draw(sp);
            }
            hpDraw(sp);
            base.Draw(sp);
        }

        public Vector2 tankPos
        {
            get { return nTank.POSITION; }
        }


        
        
    }
}
