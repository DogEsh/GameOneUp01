using System;
using UnityEngine;

namespace SimpleTeam.GameOne.GameInfo
{
    public class Circle : IObj2D
    {
        protected Vector2 _pos;
        protected float _radius;


        public Circle(Vector2 pos, float radius)
        {
            _pos = pos;
            _radius = radius;
        }

        public void SetRadius(float radius)
        {
            _radius = radius;
        }

        public Vector2 GetPos()
        {
            return _pos;
        }

        public Vector2 GetPosSurface(Vector2 destination)
        {
            Vector2 v = destination - _pos;
            v = v.normalized;
            return _pos + v*_radius;
        }

        public bool IsFocused(Vector2 pos)
        {
            Vector2 v = pos - _pos;

            if (v.magnitude < _radius)
            {
                return true;
            }
            return false;
        }
    }
}

