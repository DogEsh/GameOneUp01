using SimpleTeam.GameOne.GameInfo;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    public class GameMap : MonoBehaviour, IGameMap
    {
       
        private ITransformCoordinate _transform;
        private Dictionary<GameObjID, Simplus> _simpluses;


        public GameObjID ID{ get { return 0; } }


        public void Initialize(ITransformCoordinate tran)
        {
            _transform = tran;
        }
        private void Start()
        {
            _simpluses = new Dictionary<GameObjID, Simplus>();
            IGameMapHandler handler = gameObject.GetComponentInChildren<IGameMapHandler>();
            handler.Initialize(_simpluses);
        }



        private void Update()
        {
        }

        public Simplus GetFocusedSimplus(Vector2 focusPos)
        {
            if (_simpluses == null) return null;
            foreach (Simplus s in _simpluses.Values)
            {
                if (s.IsFocused(focusPos))
                {
                    return s;
                }
            }
            return null;
        }
     

        public IMapInfo GetInfo()
        {
            IGameMapHandler handler = gameObject.GetComponentInChildren<IGameMapHandler>();
            return handler.GetInfo();
        }

        public ITransformCoordinate GetTransform()
        {
            return _transform;
        }
    }
}
