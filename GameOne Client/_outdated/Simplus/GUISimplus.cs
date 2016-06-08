//using System;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//namespace SimpleTeam.Sce
//{
//    public class GUISimplus : Circle
//    {
//        private GameController _controller;
//        private Texture2D _texture;
//        private const float _radius = 50;
//        public Rect _pos;
//        private Rect _posBig;
//        private Rect _texPos;
//        private Simplus _myObj;
//        public GUISimplus(Simplus myObj, GameController controller, Texture2D texture, Vector2 pos) : base(pos, _radius)
//        {
//            _myObj = myObj;
//            _controller = controller;
//            _texture = texture;
//            _texPos = new Rect(0, 0, 1f / 4, 1f / 1);
//            _pos = InitRect(pos, _radius);
//            _posBig = InitRect(pos, _radius * 1.1f);
//        }
//        private Rect InitRect(Vector2 pos, float radius)
//        {
//            Rect rect;
//            rect = new Rect();
//            rect.size = new Vector2(2f * radius, 2f * radius);
//            rect.center = pos;
//            return rect;
//        }

//        public bool IsContains()
//        {
//            return IsFocus(_controller.GetMouse().Pos);
//        }
//        public void Draw()
//        {
//            if (_controller.GetLink().Focus == _myObj && _controller.GetLink().Source != _myObj)
//            {
//                GUI.DrawTextureWithTexCoords(_posBig, _texture, _texPos);
//            }
//            else
//            {
//                GUI.DrawTextureWithTexCoords(_pos, _texture, _texPos);
//            }
//        }
//        public Vector2 Pos
//        {
//            get
//            {
//                Vector2 v = _pos.center;
//                //v.y = Screen.height - v.y;
//                return v;
//            }
//        }
//    }
//}
