using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Framework.Generality.Bases;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Framework.Generality.Enemy
{
    class Enemy:EnemyControl
    {
        public Enemy(Vector2 point, Texture2D TankTex, Texture2D BullTex) :base (point, TankTex, BullTex)
        {

        }
    }
}
