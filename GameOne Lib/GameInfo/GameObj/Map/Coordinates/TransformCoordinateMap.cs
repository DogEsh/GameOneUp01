using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SimpleTeam.GameOne.GameInfo
{
    public class TransformCoordinateMap : ITransformCoordinate
    {
        private Vector2 _mapPos;

        public float Size
        {
            get
            {
                return 2*_mapPos.x;
            }
        }

        public TransformCoordinateMap(float widht, float height)
        {
            _mapPos.x = widht;
            _mapPos.y = height;
        }

        public Vector2 TransformPos(Vector2 pos)
        {
            pos.x *= _mapPos.x;
            pos.y *= _mapPos.y;
            return pos;
        }

        public Vector2 UntransformPos(Vector2 pos)
        {
            pos.x /= _mapPos.x;
            pos.y /= _mapPos.y;
            return pos;
        }
    }
}
