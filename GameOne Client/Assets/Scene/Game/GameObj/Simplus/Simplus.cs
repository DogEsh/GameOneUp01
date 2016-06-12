using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    public class Simplus : GameObjBase, ISimplus
    {
        private ITransformCoordinate _transform;
        private Dictionary<GameObjID, ISimplusLink> _links = null;
        //private SimplusGraghics _simplusGraghics;


        public override GameObjID ID
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
            _links = new Dictionary<GameObjID, ISimplusLink>();

            ISimplusHandler handler = gameObject.GetComponentInChildren<ISimplusHandler>();
            handler.Initialize(_links);

            ISimplusInfo info = handler.GetInfo();
            ISimplusGraphics graph = gameObject.GetComponentInChildren<ISimplusGraphics>();
            graph.Initialize(info, _transform);
           
        }

        private void Update()
        {
            if (base.CheckDestroy()) return;
        }

        public bool IsFocused(Vector2 focusPos)
        {
            ISimplusHandler handler = gameObject.GetComponentInChildren<ISimplusHandler>();
            ISimplusInfo info = handler.GetInfo();
            if (info == null) return false;
            return info.Obj2D.IsFocused(focusPos, _transform);
        }



        public void DestroyLinks()
        {
            foreach (GameObjID id in _links.Keys)
            {
                _links[id].RequestDestroy();
            }
            _links = null;
        }

        public override void Destroy()
        {
            DestroyLinks();
            
            Destroy(gameObject);
        }

        public ISimplusInfo GetInfo()
        {
            ISimplusHandler handler = gameObject.GetComponentInChildren<ISimplusHandler>();
            return handler.GetInfo();
        }

        public void UpdateInfo(ISimplusInfo info)
        {
            ISimplusHandler handler = gameObject.GetComponentInChildren<ISimplusHandler>();
            handler.SetInfo(info);
        }
    }
}
