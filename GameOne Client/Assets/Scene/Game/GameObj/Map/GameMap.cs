using SimpleTeam.GameOne.GameInfo;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace SimpleTeam.GameOne.Scene
{
   
    using GameObjID = UInt16;
    public class GameMap : MonoBehaviour, IGameMap
    {
        private IMapInfo _info;
        private ITransformCoordinate _transform;
        private Dictionary<GameObjID, GameObject> _simpluses = new Dictionary<GameObjID, GameObject>();

        private enum HelperStateInfo
        {
            None,
            Update,
            Init
        }
        HelperStateInfo _stateInfo;
        object _lockerInfo = new object();

        private GameObject _simplusPrefab;

        public GameObjID ID{ get { return 0; } }

        private void Start()
        {

            const string _pathSimplus = "Game/SimplusPrefab";
            _simplusPrefab = Resources.Load<GameObject>(_pathSimplus);
            InitSimplus();
            UpdateSimplus();

        }



        private void Update()
        {
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
        public void Initialize(ITransformCoordinate tran)
        {
            _transform = tran;
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
                _simpluses[s.ID].GetComponentInChildren<ISimplusHandler>().SetInfo(s);
            }
        }
        private void InitSimplus()
        {
            _simpluses = new Dictionary<GameObjID, GameObject>();
            if (_info == null) return;
            foreach (ISimplusInfo s in _info.GetContainerSimplus())
            {
                GameObject inst = Instantiate(_simplusPrefab);
                inst.transform.parent = gameObject.transform;
                
                ISimplus simplus = inst.GetComponent<ISimplus>();
                simplus.Initialize(_transform);
                _simpluses.Add(s.ID, inst);

                
            }
        }


        //GameManager
        public GameObject GetFocusedSimplus(Vector2 focusPos)
        {
            if (_simpluses == null) return null;
            foreach (GameObject inst in _simpluses.Values)
            {
                ISimplus s = inst.GetComponent<ISimplus>();
                if (s.IsFocused(focusPos))
                {
                    return inst;
                }
            }
            return null;
        }
        private void DestroySimplus()
        {
            foreach (GameObject inst in _simpluses.Values)
            {
                Destroy(inst);
            }
        }

        public IMapInfo GetInfo()
        {
            IMapInfo info;
            lock (_lockerInfo)
            {
                info = _info;
            }
            return info;
        }
    }
}
