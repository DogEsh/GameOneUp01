﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    class Cursor : MonoBehaviour, ICursor
    {
        private CursorGraphics _cursorGraghics;
        private ITransformCoordinate _transform;
        DragInfo _dragInfo;
        private SimplusAnimationManager _simplusManager;
        
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
            _cursorGraghics = new CursorGraphics(gameObject);
        }

        private void Update()
        {
            _cursorGraghics.UpdateGraghics(_dragInfo);
        }

        public void SetMouse(IMouseManager mouse)
        {
            GameObject inst = mouse.FocusSimplus;
            IObj2D obj;
            if (inst == null) obj = new Point(_transform.UntransformPos(mouse.Pos));
            else
            {
                ISimplus s = inst.GetComponent<ISimplus>();
                obj = s.GetInfo().Obj2D;
            }


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

        public void Initialize(ITransformCoordinate tran)
        {
            _transform = tran;
            _dragInfo = new DragInfo(tran);
        }
    }
}
