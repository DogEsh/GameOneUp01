using System;
using UnityEngine;

namespace SimpleTeam.GameOne.GameInfo
{
    public class Point : IObj2D
    {
        private Vector2 _pos;
        public Point(Vector2 pos)
        {
            _pos = pos;
        }

        public Vector2 Pos
        {
            get
            {
                return _pos;
            }
            set
            {
                _pos = value;
            }
        }

        public Vector2 GetPosSurface(Vector2 destination)
        {
            return _pos;
        }

        public bool IsFocused(Vector2 pos)
        {
            return pos.Equals(_pos);
        }
    }
}
