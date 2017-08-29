using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Framework.Generality.OffSets;

namespace Framework.Generality.Bases.UI
{
    public class Button
    {
        protected string _label;
        protected Texture2D _sprite;
        protected Rectangle _boundingBox;
        protected Vector2 _position;
        protected SpriteFont _font;
        protected bool _active;
        protected Color _color;

        public Button(string label)
        {
            _label = label;
            _sprite = null;
            _boundingBox = new Rectangle();
            _position = Vector2.Zero;
            _active = false;
            _color = Color.Red;
        }
        public Button()
        {
            _label = "";
            _sprite = null;
            _boundingBox = new Rectangle();
            _position = Vector2.Zero;
            _active = false;
            _color = Color.Red;
        }

        public void Init(Vector2 position, Rectangle boundingBox)
        {
            _boundingBox = boundingBox;
            _position = position;
            _active = true;
        }
        public void LoadContents(ContentManager content, string fontPath = "", string spritePath = "")
        {
            if (fontPath != "")
            {
                _font = content.Load<SpriteFont>(fontPath);
                _font.DefaultCharacter = '?';
            }
            if (spritePath != "")
            {
                _sprite = content.Load<Texture2D>(spritePath);
            }

        }

        public virtual void Draw(SpriteBatch sp)
        {
            Vector2 center = new Vector2(_position.X + _boundingBox.Width / 2, _position.Y + _boundingBox.Height / 2);
            Vector2 size = Vector2.Zero;
            GetSizeText(_label, out size.X, out size.Y);
            Vector2 textPos = center - size / 2;
            sp.DrawString(_font, _label, textPos, _color);
        }
        public virtual void Update(float deltaTime)
        {
            if (_active)
                if (IsInside())
                {
                    Hover();
                    if (InputControl.Input.Clicked(Constants.MOUSEBUTTON_LEFT))
                    {
                        Behavior();
                    }
                }
            else
                {
                    Default();
                }
        }

        protected virtual void Behavior()
        {
            // when click
        }
        protected virtual void Hover()
        {
            // effect when hover
        }
        protected virtual void Default()
        {
            // normal do nothing
        }

        protected bool IsInside()
        {
            Vector2 mousePos = InputControl.Input.GetMousePosition();
            if (mousePos.X >= 0 && mousePos.X <= _position.X + _boundingBox.Width
                && mousePos.Y >= 0 && mousePos.Y <= _position.Y + _boundingBox.Height)
            {
                return true;
            }
            return false;
        }
        protected void GetSizeText(string text, out float width, out float height)
        {
            Vector2 size = _font.MeasureString(text);
            width = size.X;
            height = size.Y;
        }
    }
}
