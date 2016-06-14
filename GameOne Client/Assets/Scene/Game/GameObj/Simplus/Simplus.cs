using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    public class Simplus : MonoBehaviour, ISimplus
    {
        private ITransformCoordinate _transform;


        public  GameObjID ID
        {
            get
            {
                ISimplusHandler handler = gameObject.GetComponentInChildren<ISimplusHandler>();
                ISimplusInfo info = handler.GetInfo();
                return info.ID;
            }
        }

        public void Initialize(ITransformCoordinate tran)
        {
            _transform = tran;
        }

        private void Start()
        { 

            ISimplusHandler handler = gameObject.GetComponentInChildren<ISimplusHandler>();

            ISimplusInfo info = handler.GetInfo();
            ISimplusGraphics graph = gameObject.GetComponentInChildren<ISimplusGraphics>();
            graph.Initialize(info, _transform);
           
        }

        private void Update()
        {
        }

        public bool IsFocused(Vector2 focusPos)
        {
            ISimplusHandler handler = gameObject.GetComponentInChildren<ISimplusHandler>();
            ISimplusInfo info = handler.GetInfo();
            if (info == null) return false;
            return info.Obj2D.IsFocused(focusPos, _transform);
        }


        public ISimplusInfo GetInfo()
        {
            ISimplusHandler handler = gameObject.GetComponentInChildren<ISimplusHandler>();
            return handler.GetInfo();
        }
    }
}
