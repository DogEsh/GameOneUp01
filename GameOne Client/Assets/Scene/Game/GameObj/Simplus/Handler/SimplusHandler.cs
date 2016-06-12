using System;
using System.Collections.Generic;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    class SimplusHandler : MonoBehaviour, ISimplusHandler
    {
        private Dictionary<GameObjID, ISimplusLink> _links;
        GameObject _mySimplus;
        private GameObject _linkPrefab;



        private ISimplusInfo _info;
        HelperStateInfo _stateInfo;
        object _lockerInfo = new object();
        private enum HelperStateInfo
        {
            None,
            Update
        }
        
        private void Start()
        {
            _stateInfo = HelperStateInfo.None;
            _mySimplus = gameObject.transform.parent.gameObject;
            const string pathLink = "Game/SimplusLinkPrefab";
            _linkPrefab = Resources.Load<GameObject>(pathLink);
        }

        public void SetInfo(ISimplusInfo info)
        {
            lock (_lockerInfo)
            {
                _info = info;
                _stateInfo = HelperStateInfo.Update;
            }
        }

        private void Update()
        {
            if (_stateInfo == HelperStateInfo.None) return;

            lock (_lockerInfo)
            {
                if (_stateInfo == HelperStateInfo.Update)
                {
                    DestroyExcessLinks();
                    InitLinks();
                    UpdateLinks();
                    _stateInfo = HelperStateInfo.None;
                }
            }
        }
        public void InitLinks()
        {
            foreach (ISimplusLinkInfo inf in _info.Links)
            {
                if (!_links.ContainsKey(inf.ID))
                {
                    GameObject inst = Instantiate(_linkPrefab);
                    inst.transform.parent = gameObject.transform;
                    ISimplusLink link = inst.GetComponent<ISimplusLink>();
                    _links.Add(inf.ID, link);
                }
            }
        }
        public void DestroyExcessLinks()
        {
            foreach (GameObjID id in _links.Keys)
            {
                ISimplusLinkInfo tmp = _info.Links.GetObj(id);
                if (tmp == null)
                {
                    _links[id].RequestDestroy();
                    _links.Remove(id);
                }
            }
        }
        public void UpdateLinks()
        {
            foreach (ISimplusLinkInfo inf in _info.Links)
            {
                _links[inf.ID].UpdateInfo(inf);
            }
        }

        public void Initialize(Dictionary<ushort, ISimplusLink> links)
        {
            _links = links;
        }

        public ISimplusInfo GetInfo()
        {
            ISimplusInfo i;
            lock (_lockerInfo)
            {
                i = _info;
            }
            return i;
        }
    }
}
