

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Framework.Generality.Bases.ParticleSystem
{
    public class ParticleSystem
    {
        protected List<Particle> _particles;
        protected List<Texture2D> _textures;

        public ParticleSystem(List<Texture2D> textures)
        {
            _particles = new List<Particle>();
            _textures = textures;
        }

        public void Update(float deltaTime)
        {
            foreach(Particle par in _particles)
            {
                par.Update(deltaTime);
            }
        }
        public void Draw(SpriteBatch sp)
        {
            foreach (Particle par in _particles)
            {
                par.Draw(sp);
            }
       
        }

        public void Add()
        {
            if(_particles.Count <= 100)
            {
                int count = 0;
                Emitter.EmitterStruct offSet = new Emitter.EmitterStruct();
                RandomMaxMin rd = new RandomMaxMin();
                while (count < 10)
                {
                    _particles.Add(new Particle(offSet, _textures[rd.RandomInt(0, _textures.Count - 1)]));
                    count++;
                }
            }
        }
    }
}
