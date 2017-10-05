

using Framework.Generality.Managers;
using Framework.Generality;
using Framework.Generality.Bases;
using Framework.Generality.Enemy;
using Framework.Generality.InputControl;
using Framework.Generality.OffSets;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Framework.MainTank;
using Framework.Generality.Bases.Camera2D;

using Framework.Generality.Bases.ParticleSystem;
using Framework.Generality.Particles;
using Framework.Generality.Manager;
using Framework.Generality.Bases.GameScenes;
using System.Collections.Generic;
using System;
//using Framework.Generality.Bases.Network;
using Framework.Generality.ColisionDetection;

namespace Framework.Generality.Bases.GameScenes
{
    public class PlayScene : Scene
    {
        private List<Item> listItem;
        private GateControl Gate;
        private Tank nTank;
        private Item nItem;
        private Camera Cam;
        private float delayTime = 0f;

        // test smartfox
        //Connection _network;
        public PlayScene(ContentManager contents) :
            base(Constants.SCENE_PLAY, contents)
        {
            Gate = new GateControl(contents);
            nTank = new Tank();
            Cam = new Camera();
            listItem = new List<Item>();

            // test smartfox
            //_network = new Connection();
        }

        public override bool Init()
        {
            _isInit = LoadContents();

            // test smartfox
            //_network.Init();
            //_network.SendConnectRequest();
            return _isInit;
        }
        public override void Shutdown()
        {
            _contents.Unload();
            _isInit = false;
        }
        public override void Draw(SpriteBatch sp)
        {
            sp.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Cam.GetTransfromMatrix());
            //Gate.Draw(sp);
            Gate.Draw(sp);
            nTank.Draw(sp);
            foreach (Item i in listItem)
            {
                i.Draw(sp);
            }
            sp.End();
        }
        public override GameManager.GameState Update(float deltaTime)
        {
            //Gate.Updata(deltaTime);
            nTank.Update(deltaTime);
            
            //Cam.Update(deltaTime, nTank.POSITION);
            itemUpdate(deltaTime);
            CheckCollision();
            // test smartfox
            //_network.Update();
            return GameManager.GameState.None;
        }
        public override bool LoadContents()
        {
            nTank.LoadContents(_contents);
            return true;
        }

        private void itemUpdate(float deltaTime)
        {
            if (delayTime >= 5f)
            {
                if (listItem.Count < 3)
                {
                    listItem.Add(nItem = new Item(randomImage()));
                }
                delayTime = 0f;
            }
            else
                delayTime += deltaTime;
        }
        public Texture2D randomImage()
        {
            Texture2D itemImage;
            Random rd = new Random();
            int randomValue = rd.Next(1, 3);
            if (randomValue == 1)
                return itemImage = _contents.Load<Texture2D>("item");
            if (randomValue == 2)
                return itemImage = _contents.Load<Texture2D>("item1");
            if (randomValue == 3)
                return itemImage = _contents.Load<Texture2D>("item2");
            else return null;
        }

        /// <summary>
        /// 
        /// </summary>
        protected Quadtree _quad = new Quadtree(0, new Microsoft.Xna.Framework.Rectangle(0, 0, 1000, 674));
        protected List<Object> _tempList = new List<Object>();
        protected void CheckCollision()
        {
            _quad.Clear();
            List<Object> objCollision = new List<Object>();
            _tempList = GameManager.GetAllObject();
            for (int i = 0; i < _tempList.Count; i++)
            {
                _quad.Insert(_tempList[i]);
            }
            for (int i = 0; i < _tempList.Count; i++)
            {
                objCollision.Clear();
                objCollision = _quad.Retrieve(objCollision, _tempList[i]);
                for(int x  = 0; x < objCollision.Count; x++)
                {
                    
                }
            }
        }
    }
}
