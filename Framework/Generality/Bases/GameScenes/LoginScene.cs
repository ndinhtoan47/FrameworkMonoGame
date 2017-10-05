﻿using Framework.Generality.Managers;
using Framework.Generality.OffSets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Framework.Generality.Bases.UI;

namespace Framework.Generality.Bases.GameScenes
{
    public class LoginScene : Scene
    {
        protected Texture2D BG;
        protected Texture2D LoginBG;
        protected Rectangle rec1;
        protected Rectangle rec2;
        protected Rectangle rec3;
        protected Rectangle rec4;
        protected DemoButton ID;
        protected DemoButton PASS;
        protected DemoButton LOGIN;
        
        

        public LoginScene(ContentManager contents) :
            base(Constants.SCENE_LOGIN, contents)
        {
            _contents = contents;
            rec1 = new Rectangle(0, 0, 800, 600);
            rec2 = new Rectangle(0, 0, 1280, 720);
            //rec3 = new Rectangle(300, 100, 200, 50);
            //rec4 = new Rectangle(0, 0, 518, 109);
            ID = new DemoButton( new Vector2(150, 250), new Rectangle(0, 0, 150, 50));
            PASS = new DemoButton(new Vector2(300, 250), new Rectangle(0, 0, 150, 50));
            LOGIN = new DemoButton(new Vector2(450, 250), new Rectangle(0, 0, 150, 50));
        }

        public override bool Init()
        {
            _isInit = LoadContents();
            return _isInit;
        }
        public override void Shutdown()
        {
            _contents.Unload();
            _isInit = false;
        }
        public override void Draw(SpriteBatch sp) 
        {
            sp.Begin();
            sp.Draw(BG = _contents.Load<Texture2D>("BG"),rec1,sourceRectangle:rec2, color:Color.Wheat);
            //sp.Draw(LoginBG = _contents.Load<Texture2D>("Login"), rec3, sourceRectangle: rec4, color: Color.Wheat);
            LOGIN.ButtonDraw(sp);
           if(ID.isClick())
            ID.TestDraw(sp);
           else
               ID.ButtonDraw(sp);
           if (PASS.isClick())
               PASS.TestDraw(sp);
           else
               PASS.ButtonDraw(sp);
            sp.End();
        }
        public override GameManager.GameState Update(float deltaTime)
        {
            MouseState mouse;
            mouse = Mouse.GetState();
            
         
            if(ID.isClick())
            {
                ID.UpdateTest(deltaTime, mouse);
                PASS.NonActive();
            }
            if (PASS.isClick())
            {
                PASS.UpdateTest(deltaTime, mouse);
                ID.NonActive();
            }
            ID.Update(deltaTime, mouse);
            LOGIN.Update(deltaTime, mouse);
            PASS.Update(deltaTime, mouse);
            //if (Keyboard.GetState().IsKeyDown(Keys.Enter) && prekey.IsKeyUp(Keys.Enter))
            //{
            //    if (name.Length > 3)
            //    {
            //        f_name = name;
            //    }
            //}

            //prekey = Keyboard.GetState();
            //GetKey();
            return GameManager.GameState.None;
        }
        public override bool LoadContents()
        {
            ID.LoadContents(_contents, "font", "ID");
            PASS.LoadContents(_contents, "font", "PASS");
            LOGIN.LoadContents(_contents, "font", "Login");
            return true; 
        }
    }
}
