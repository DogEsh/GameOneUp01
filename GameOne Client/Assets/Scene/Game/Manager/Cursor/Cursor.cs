using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    class Cursor : MonoBehaviour, ICursor
    {
        public GameObject MyInstance;
        private CursorGraphics _cursorGraghics;
        DragInfo _dragInfo = new DragInfo();
        
        public Vector2 GetSource()
        {
            return _dragInfo.GetPosSource();
        }
        public Vector2 GetDestination()
        {
            return _dragInfo.GetPosDestination();
        }
        private void Start()
        {
            _cursorGraghics = new CursorGraphics(MyInstance);
        }

        private void Update()
        {
            _cursorGraghics.UpdateGraghics(_dragInfo);
        }

        public void SetMouse(IMouseManager mouse)
        {
            ISimplus s = mouse.FocusSimplus;
            IObj2D obj;
            if (s == null) obj = new Point(mouse.Pos);
            else obj = s.GetInfo().Obj2D;


            if (HelperMouseState.Down == mouse.State.Get())
            {
                _dragInfo.SetSource(obj);
                _dragInfo.SetDestination(obj);
                _cursorGraghics.UpdateGraghics(_dragInfo);
                _cursorGraghics.SetGraghicsActive(true);
            }
            if (HelperMouseState.Pressed == mouse.State.Get())
            {
                _dragInfo.SetDestination(obj);
            }
            if (HelperMouseState.Up == mouse.State.Get())
            {
                _cursorGraghics.SetGraghicsActive(false);
            }
        }
    }
}
