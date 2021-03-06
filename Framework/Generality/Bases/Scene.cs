﻿using Framework.Generality.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Generality.Bases
{
    public abstract class Scene
    {
        protected string _name;
        protected bool _isInit;
        protected ContentManager _contents;

        public Scene(string name, ContentManager contents)
        {
            _name = name;
            _contents = contents;
            _isInit = false;
        }

        public Scene()
        {
        }

        public virtual bool Init() 
        {
            _isInit = LoadContents();            
            return _isInit; 
        }
        public virtual void Shutdown()
        {
            _contents.Unload();
            _isInit = false;
        }
        public virtual void Draw(SpriteBatch sp) { }
        public virtual GameManager.GameState Update(float deltaTime) 
        {
            return GameManager.GameState.None;
        }
        public virtual bool LoadContents() { return true; }

        // properties
        public bool INIT
        {
            get { return _isInit; }
            protected set { _isInit = value; }
        }
        public string NAME
        {
            get { return _name; }
            set { _name = value; }
        }
        protected ContentManager CONTENTS
        {
            get { return _contents; }
            set { _contents = value; }
        }
    }
}
