using SimpleTeam.GameOne.GameInfo;
using System.Collections.Generic;
using System;
using UnityEngine;



namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    class GameMapHandler : MonoBehaviour, IGameMapHandler
    {

        private Dictionary<GameObjID, Simplus> _simpluses;
        private IConcurrentInfo<IMapInfo> _containerInfo = new ConcurrentInfo<IMapInfo>();

        private GameObject _simplusPrefab;




        public void Initialize(Dictionary<GameObjID, Simplus> simpluses)
        {
            _simpluses = simpluses;
        }

        private void Start()
        {
            const string _pathSimplus = "Game/SimplusPrefab";
            _simplusPrefab = Resources.Load<GameObject>(_pathSimplus);
        }



        private void Update()
        {
            KeyValuePair<HelperStateInfo, IMapInfo> pair;
            pair = _containerInfo.GetInfo(true);
            if (pair.Key == HelperStateInfo.None) return;



            if (pair.Key == HelperStateInfo.Init)
            {
                DestroySimplus();
                InitSimplus(pair.Value);
                UpdateSimplus(pair.Value);
            }
            else if (pair.Key == HelperStateInfo.Update)
            {
                UpdateSimplus(pair.Value);
            }
        }

        private void DestroySimplus()
        {
            foreach (Simplus s in _simpluses.Values)
            {
                Destroy(s.gameObject);
            }
            _simpluses.Clear();
        }
        private void InitSimplus(IMapInfo info)
        {
            if (info == null) return;
            foreach (ISimplusInfo s in info.GetContainerSimplus())
            {
                GameObject inst = Instantiate(_simplusPrefab);

                GameMap map = gameObject.GetComponentInParent<GameMap>();
                inst.transform.parent = gameObject.transform.parent;

                Simplus simplus = inst.GetComponent<Simplus>();
                simplus.Initialize(map.GetTransform());
                _simpluses.Add(s.ID, simplus);
            }
        }
        private void UpdateSimplus(IMapInfo info)
        {
            foreach (ISimplusInfo s in info.GetContainerSimplus())
            {
                _simpluses[s.ID].GetComponentInChildren<ISimplusHandler>().SetToUpdateInfo(s);
            }
        }


        public void SetToInitInfo(IMapInfo info)
        {
            _containerInfo.SetInfo(info, HelperStateInfo.Init);
        }

        public void SetToUpdateInfo(IMapInfo info)
        {
            _containerInfo.SetInfo(info, HelperStateInfo.Update);
        }
        public IMapInfo GetInfo()
        {
            return _containerInfo.GetInfo().Value;
        }
    }
}
