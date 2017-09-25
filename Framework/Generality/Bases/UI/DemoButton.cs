﻿using Framework.Generality.OffSets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Framework.Generality.Bases.UI
{
    public class DemoButton : Button
    {
        public DemoButton()
            :base("")
        {
            _position = new Vector2(50, 50);
            _boundingBox.Width = 50;
            _boundingBox.Height = 50;
        }

        public override void Draw(SpriteBatch sp)
        {
            sp.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, _boundingBox.Width, _boundingBox.Height), _color);
            base.Draw(sp);
        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        protected override void Behavior()
        {
            _color = Color.White;
            _active = false;
            base.Behavior();
        }
        protected override void Hover()
        {
            _color = Color.Purple;
            base.Hover();
        }
        protected override void Default()
        {
            _color = Color.Red;
            base.Default();
        }
    }
}
