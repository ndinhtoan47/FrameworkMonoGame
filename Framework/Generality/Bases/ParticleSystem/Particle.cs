using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Generality.Bases.ParticleSystem
{
    public class Particle
    {
        private Texture2D _sprite;
        private Vector2 _position;
        private float _speed;
        private float _lifeTime;
        private float _totalLifeTime;
        private int _direction;
        private float _rotation;
        private float _rotationSpeed;
        private Vector2 _center;
        private int _fade;
        private float _scale;
        private int _startOpacity;
        private Emitter.EmitterStruct _emiterStr;
        // shape process
        private int _minX;
        private int _maxX;
        private int _minY;
        private int _maxY;
        private int _radius;
        private Vector2 _shapePosition;

        public Particle(Emitter.EmitterStruct emiterStruct,Texture2D _sprite)
        {
            #region Type box init 
            if (emiterStruct._shapeStruct._shape == Emitter.Shape.Box)
            {
                _minX = emiterStruct._shapeStruct._minX;
                _minY = emiterStruct._shapeStruct._minY;
                _maxX = emiterStruct._shapeStruct._maxX;
                _maxY = emiterStruct._shapeStruct._maxY;
                _radius = 0;
            }
            #endregion
            #region Type edge init
            if (emiterStruct._shapeStruct._shape == Emitter.Shape.Edge)
            {
                _minX = emiterStruct._shapeStruct._minX;
                _minY = 0;
                _maxX = emiterStruct._shapeStruct._maxX;
                _maxY = 0;
                _radius = 0;
            }
            #endregion
            #region Type circle init
            if (emiterStruct._shapeStruct._shape == Emitter.Shape.Circle)
            {
                _minX = 0;
                _minY = 0;
                _maxX = 0;
                _maxY = 0;
                _radius = emiterStruct._shapeStruct._radius;
            }
            #endregion
            _emiterStr = emiterStruct;
        }

        public void Update(float deltaTime)
        {
            if(_emiterStr._shapeStruct._shape == Emitter.Shape.Box)
            {

            }
            if (_emiterStr._shapeStruct._shape == Emitter.Shape.Edge)
            {

            }
            if (_emiterStr._shapeStruct._shape == Emitter.Shape.Circle)
            {

            }
        }
    }
}
