using SimpleTeam.GameOne.GameInfo;
using System.Collections.Generic;
using System;

namespace SimpleTeam.GameOne.Scene
{
    using UnityEngine;
    using GameObjID = UInt16;
    class GameMap : IGameMap
    {
        private IMapInfo _mapInfo;
        private Dictionary<GameObjID, ISimplus> _simpluses = null;

        //NetworkMap
        public void SetToInit(IMapInfo mapInfo)
        {
            _mapInfo = mapInfo;
            Clear();
            Init();
        }
        public void SetToUpdate(IMapInfo mapInfo)
        {
            _mapInfo = mapInfo;
            Update();
        }

        private void Update()
        {
            foreach (ISimplusInfo s in _mapInfo.GetContainerSimplus())
            {
                _simpluses[s.ID].UpdateInfo(s);
            }
        }
        private void Init()
        {
            _simpluses = new Dictionary<GameObjID, ISimplus>();
            foreach (ISimplusInfo s in _mapInfo.GetContainerSimplus())
            {
                _simpluses.Add(s.ID, new Simplus(s));
            }
        }
        private void Clear()
        {
            if (_simpluses != null)
            {
                foreach (ISimplus s in _simpluses.Values)
                {
                    s.Destroy();
                }
                _simpluses = null;
            }
        }


        //GameManager
        public ISimplus GetFocusedSimplus(Vector2 focusPos)
        {
            foreach (ISimplus s in _simpluses.Values)
            {
                if (s.IsFocused(focusPos))
                {
                    return s;
                }
            }
            return null;
        }
    }
}
