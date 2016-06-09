using SimpleTeam.GameOne.GameInfo;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace SimpleTeam.GameOne.Scene
{
   
    using GameObjID = UInt16;
    public class GameMap : GameObjBase, IGameMap
    {
        private IMapInfo _info;
        private Dictionary<GameObjID, ISimplus> _simpluses = null;

        private enum HelperStateInfo
        {
            None,
            Update,
            Init
        }
        HelperStateInfo _stateInfo;
        object _lockerInfo = new object();


        private string _pathSimplus = "Game/SimplusPrefab";
        private GameObject _simplusPrefab;

        public override GameObjID ID{ get { return 0; } }

        private void Start()
        {
            _simplusPrefab = Resources.Load<GameObject>(_pathSimplus);
            InitSimplus();
            UpdateSimplus();
        }



        private void Update()
        {
            if (base.CheckDestroy()) return;
            if (_info == null) return;
            CheckInfo();
            
        }

        private void CheckInfo()
        {
            if (_stateInfo == HelperStateInfo.None) return;

            lock (_lockerInfo)
            {
                if (_stateInfo == HelperStateInfo.Init)
                {
                    DestroySimplus();
                    InitSimplus();
                    _stateInfo = HelperStateInfo.Update;
                }

                if (_stateInfo == HelperStateInfo.Update)
                {
                    UpdateSimplus();
                    _stateInfo = HelperStateInfo.None;
                }
            }
        }
        //NetworkMap
        public void InitInfo(IMapInfo info)
        {
            lock (_lockerInfo)
            {
                _info = info;
                _stateInfo = HelperStateInfo.Init;
            }
        }
        public void UpdateInfo(IMapInfo info)
        {
            lock (_lockerInfo)
            {
                _info = info;
                _stateInfo = HelperStateInfo.Update;
            }
        }

        private void UpdateSimplus()
        {
            foreach (ISimplusInfo s in _info.GetContainerSimplus())
            {
                _simpluses[s.ID].UpdateInfo(s);
            }
        }
        private void InitSimplus()
        {
            _simpluses = new Dictionary<GameObjID, ISimplus>();
            if (_info == null) return;
            foreach (ISimplusInfo s in _info.GetContainerSimplus())
            {
                GameObject inst = Instantiate(_simplusPrefab);
                inst.transform.parent = gameObject.transform;
                ISimplus simplus = inst.GetComponent<ISimplus>();
                _simpluses.Add(s.ID, simplus);
            }
        }
        private void DestroySimplus()
        {
            if (_simpluses != null)
            {
                foreach (ISimplus s in _simpluses.Values)
                {
                    s.RequestDestroy();
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

        public override void Destroy()
        {
            DestroySimplus();
            Destroy(gameObject);
        }
    }
}
