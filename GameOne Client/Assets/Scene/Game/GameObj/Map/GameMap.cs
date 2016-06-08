using SimpleTeam.GameOne.GameInfo;
using System.Collections.Generic;
using System;

namespace SimpleTeam.GameOne.Scene
{
    using UnityEngine;
    using GameObjID = UInt16;
    class GameMap : MonoBehaviour, IGameMap
    {
        private IMapInfo _info;
        private Dictionary<GameObjID, ISimplus> _simpluses = null;


        private string _pathSimplus = "wtf";
        private GameObject _simplusPrefab;

        public ushort ID {get {return 0;}}

        private void Start()
        {
            _simplusPrefab = Resources.Load<GameObject>(_pathSimplus);
        }
        //NetworkMap
        public void SetToInitInfo(IMapInfo info)
        {
            _info = info;
            ClearInfo();
            InitInfo();
        }
        public void SetToUpdateInfo(IMapInfo info)
        {
            _info = info;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            foreach (ISimplusInfo s in _info.GetContainerSimplus())
            {
                _simpluses[s.ID].UpdateInfo(s);
            }
        }
        private void InitInfo()
        {
            _simpluses = new Dictionary<GameObjID, ISimplus>();
            foreach (ISimplusInfo s in _info.GetContainerSimplus())
            {
                _simpluses.Add(s.ID, new Simplus());
            }
        }
        private void ClearInfo()
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

        public void SetToInit(IMapInfo mapInfo)
        {
            throw new NotImplementedException();
        }

        public void SetToUpdate(IMapInfo mapInfo)
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
