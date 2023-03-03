using System;
using UnityEngine;
using System.Collections.Generic;

namespace Asteroids.Model
{
    public class ArmyEnemy : Enemy
    {
        private readonly float _speed;
        private Vector2 _targetPosition;
        private ArmyEnemy _target;
        private Vector2 _lastTargetPositon;
        private Vector2 _startPositon;
        private int _countTargetPosition = 0;

        public ArmyEnemy(Vector2 target, Vector2 position, float speed) : base(position, 0)
        {
            _targetPosition = target;
            _speed = speed;
            _startPositon = position;
        }

        public override void Update(float deltaTime)
        {
            if (_countTargetPosition > 100)
            {
                _targetPosition = _startPositon;
            }
            if(_target.Position == _lastTargetPositon)
            {
                _countTargetPosition += 1;
               
            }
            else
            {
                _countTargetPosition = 0;
                _lastTargetPositon = _target.Position;
            }
            Vector2 nextPosition = Vector2.MoveTowards(Position, _targetPosition, _speed * deltaTime);
       
            if (nextPosition == Position)
            {
                Destroy();
            }
            MoveTo(nextPosition);
            LookAt(_targetPosition);
        }

        private void LookAt(Vector2 point)
        {
            Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, -(Position - point)));
        }

        public void setTarget(ArmyEnemy target)
        {
            _target = target;
            _lastTargetPositon = target.Position;
        }

        public Vector2 getPosition()
        {
            return Position;
        }
    }
}
