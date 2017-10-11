using Microsoft.Xna.Framework.Input;
using System;
using Framework.Generality.Managers;
using Framework.Generality.OffSets;
using Framework.Generality.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Framework.Generality.Bases.UI;


namespace Framework.Generality.Bases.GameScenes
{
    public class MenuScene : Scene
    {
       
        protected Texture2D backgroundMenu;
        protected SpriteFont font;
        protected DemoButton Battlebutton;
        protected DemoButton SoloButton;
        protected DemoButton CustumeButton;
        protected DemoButton PvPButton;
        protected DemoButton Exit;
        protected DemoButton LvBar;
        protected Texture2D EXP;
        protected Number Numlv;
        public Vector2 Exp= new Vector2(1,100);
        
        public float Lv = 1;
            protected Rectangle ExpPoi,ExpDeru;

        protected SBackground sBG;
        //protected SEffect sE;
       

        public MenuScene(ContentManager contents) :
            base(Constants.SCENE_MENU, contents)
        {
            //image = null;
            Battlebutton = new DemoButton(new Vector2(300,150), new Rectangle(0,0,200,200));
            SoloButton = new DemoButton(new Vector2(152,160), new Rectangle(0,0,200,50));
            CustumeButton = new DemoButton(new Vector2(480,200), new Rectangle(0,0,200,50));
            PvPButton = new DemoButton(new Vector2(), new Rectangle());
            Exit = new DemoButton(new Vector2(700,500), new Rectangle(0,0,100,100));
            LvBar = new DemoButton(new Vector2(0,0), new Rectangle(0,0,200,100));
            //ExpPoi = new Rectangle(13, 35, 172, 28);
            //ExpDeru = new Rectangle(0, 0, 552, 90);
            sBG = new SBackground();
            Numlv = new Number(_contents, new Rectangle(70, 15, 20, 20), new Rectangle(0, 0, 164, 324));
            //sE = new SEffect();
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
            sp.Draw(backgroundMenu, new Rectangle(0, 0, 800, 600), Color.White);
          
            LvBar.ButtonDraw(sp);
            sp.Draw(EXP, ExpPoi, ExpDeru, Color.Wheat);
            Battlebutton.ButtonDraw(sp);

            if (Battlebutton.Num() % 2 == 0)
            {
                SoloButton.ButtonDraw(sp);
                CustumeButton.ButtonDraw(sp);
            }
           
            Numlv.Draw(sp);
            Exit.ButtonDraw(sp);
            sp.DrawString(font, "", new Vector2(400, 150), Color.White);
            
            sp.End();
        }
        public override GameManager.GameState Update(float deltaTime)
        {
             MouseState mouse;
            mouse = Mouse.GetState();
            Numlv.UPdata((int)Lv);
            Battlebutton.Update(deltaTime, mouse);
            //Battlebutton.IsClickUp(mouse);
            SoloButton.Update(deltaTime, mouse);
            CustumeButton.Update(deltaTime, mouse);
            Exit.Update(deltaTime, mouse);
            ExpDraw(Exp.X, Exp.Y);
            ExpUp(deltaTime);
            if(SoloButton.isClick())
            {
                Game1.sceneManager.GotoScene(Constants.SCENE_PLAY);
            }
            if (Exit.isClick())
            {
               this.Shutdown();
            }
            return GameManager.GameState.None;
        }
        public void ExpDraw(float exp, float expBot)
        {
            ExpPoi.X = 14; ExpPoi.Y = 36; ExpPoi.Height = 28;
            ExpDeru.X = 0; ExpDeru.Y = 0; ExpDeru.Height = 90;
            ExpPoi.Width = (int)((172 / expBot) * exp);
            ExpDeru.Width = (int)((552 / expBot) * exp);


        }
        public void ExpUp(float deltatime)
        {
            //Exp.X +=50000* deltatime;
           
            if(Exp.X>Exp.Y)
            {
                Exp.X = 0;
                Exp.Y = Lv * 100;
                Lv++;
            }

        }
        public override bool LoadContents()
        {
            EXP = _contents.Load<Texture2D>("LVBarFULL");

     
            backgroundMenu = _contents.Load<Texture2D>("_MenuBG");
            LvBar.LoadContents(_contents, "font", "ULvBar");
            Battlebutton.LoadContents(_contents, "font", "PlayButton2");
            SoloButton.LoadContents(_contents, "font", "SoloButton");
            CustumeButton.LoadContents(_contents, "font", "CustumeButton2");
            font = _contents.Load<SpriteFont>("menufont");
            sBG.LoadContents(_contents, "sBG");
            Exit.LoadContents(_contents, "font", "Exit");
           
            return true;
        }


    }
}
