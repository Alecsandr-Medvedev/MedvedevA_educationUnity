using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class Ship : Transformable, IUpdatable
    {
        public Ship(Vector2 position, float rotation) : base(position, rotation) { }

        private readonly float _unitsPerSecond = 0.001f;
        private readonly float _maxSpeed = 0.0015f;
        private readonly float _secondsToStop = 1f;
        private readonly float _degreesPerSecond = 180;
        private int _countLives = 3;
        private float _maxTimeImmortality = 1;
        private float _nowTimeImmortality = 0;

        public Vector2 Acceleration { get; private set; }

        public void Accelerate(float deltaTime)
        {
            Acceleration += Forward * (_unitsPerSecond * deltaTime);
            Acceleration = Vector2.ClampMagnitude(Acceleration, _maxSpeed);
        }

        public void Slowdown(float deltaTime)
        {
            Acceleration -= Acceleration * (deltaTime / _secondsToStop);
        }

        public void Rotate(float direction, float deltaTime)
        {
            if (direction == 0)
                throw new InvalidOperationException(nameof(direction));

            direction = direction > 0 ? 1 : -1;

            Rotate(direction * deltaTime * _degreesPerSecond);
        }

        public void Update(float deltaTime)
        {
            Move(Acceleration);
            if (_nowTimeImmortality > 0)
            {
                _nowTimeImmortality -= deltaTime;
            }
            else if (_nowTimeImmortality < 0)
            {
                _nowTimeImmortality = 0;
            }

        }

        private void Move(Vector2 delta)
        {
            var nextPosition = Position + delta;

            nextPosition.x = Mathf.Repeat(nextPosition.x, 1);
            nextPosition.y = Mathf.Repeat(nextPosition.y, 1);

            MoveTo(nextPosition);
        }

        public void subtractLife()
        {
            if (_nowTimeImmortality == 0)
            {
                _nowTimeImmortality = _maxTimeImmortality;
                _countLives -= 1;
                if (_countLives < 0)
                {
                    _countLives = 0;
                }
            }
            
        }

        public bool isAlive()
        {
            if (_countLives == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public int getLives()
        {
            return _countLives;
        }
    }
}
