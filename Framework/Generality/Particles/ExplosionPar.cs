using Framework.Generality.Bases.ParticleSystem;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Generality.Particles
{
    public class ExplosionPar: ParticleSystem
    {
        public ExplosionPar() : base()
        {
            _minSize = 40;
        }

        public override void Update(float deltaTime)
        {
            if(InputControl.Input.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.P))
            {
                AddPar();
            }
            base.Update(deltaTime);
        }
        public override void Draw(SpriteBatch sp)
        {
            base.Draw(sp);
        }
        public override void LoadContents(ContentManager contents)
        {
            for (int i = 0; i + 0 < 7 ; i++)
                _textures.Add(contents.Load<Texture2D>(@"Particles\Explosion\" + i.ToString()));

            base.LoadContents(contents);
        }
        public override void AddPar()
        {
            if (_particles.Count < 50)
            {
                int count = 0;
                while (count < 15)
                {
                    _particles.Add(new Particle(_textures[_rd.RandomInt(0, _textures.Count - 1)],
                                                 new Microsoft.Xna.Framework.Vector2(_rd.RandomInt(95, 100), _rd.RandomInt(20, 30)),
                                                 _rd.RandomInt(3,10),
                                                 (float)(_rd.RandomDouble() + 1.50d),
                                                 _rd.RandomInt(-30, 330),
                                                 (float)_rd.RandomDouble(),
                                                 1.0f,
                                                 _minSize,
                                                 1.0f,
                                                 255));
                    count++;
                }
            }
            base.AddPar();
        }
    }
}
