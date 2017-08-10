using Microsoft.Xna.Framework;

namespace Framework.Generality.Bases.ParticleSystem
{
    public class Emitter
    {
        public enum Shape
        {
            Box,
            Circle,
            Edge
        } 
        public struct ShapeStruct
        {
            public Shape _shape;
            public Vector2 _shapePosition; // the position of the shape
            public int _minX; // use when shape == edge || box
            public int _minY; // use when shape == box
            public int _maxX; // use when shape == edge || box
            public int _maxY; // use when shape == box
            public int _radius; // use when shape == cirle
        }
        public struct EmitterStruct
        {
            public float _duration; // The lenght of time the partcle system is emitting particles.
            public float _startDelayTime; // Delay in a time unit that this particle system will wait before emtting particles.
            public bool _loop; // If true, the duration time will dedicate the lenght of one cycle.
            public float _startLifeTime; // Lifetime in a time unit, the particle will die when its lifetime reachs 0.
            public int _startSpeed; // Start speed of particles, applied in the starting direction.
            public int _startSize; // Start size of particles.
            public float _startRotation; // The start rotation of particles in degrees.
            public int _maxParticle; // The number of particles in the system will be limited by this number. Emission temporarily halted if this is reached.
            public ShapeStruct _shapeStruct;

        }
    }
}
