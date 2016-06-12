using System;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    class TransformCoordinateScreen : ITransformCoordinateScreen
    {
        private ITransformCoordinate _map;
        private Vector2 _screenPos;

        public float Size
        {
            get
            {
                return _screenPos.x;
            }
        }

        public Vector2 TransformPos(Vector2 pos)
        {
            pos.x *= _screenPos.x;
            pos.y *= _screenPos.y;
            return pos;
        }

        public Vector2 UntransformPos(Vector2 pos)
        {
            pos.x /= _screenPos.x;
            pos.y /= _screenPos.y;
            return pos;
        }
        public TransformCoordinateScreen(ITransformCoordinate map)
        {
            _map = map;
            Update();
        }
        public void Update()
        {
            Vector2 s;
            s.x = Screen.width;
            s.y = Screen.height;
            Vector2 vs = Camera.main.ScreenToWorldPoint(s);
            Vector2 delt = _map.UntransformPos(vs);
            if (delt.y > delt.x)
            {
                vs.y *= delt.x / delt.y;
            }
            else
            {
                vs.x *= delt.y / delt.x;
            }
            _screenPos = vs;
        }
    }
}
