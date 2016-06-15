using System;
using System.Collections.Generic;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    class SimplusHandler : MonoBehaviour, ISimplusHandler
    {
        private Dictionary<GameObjID, SimplusLink> _links;
        GameObject _mySimplus;
        private GameObject _linkPrefab;


        private IConcurrentInfo<ISimplusInfo> _containerInfo = new ConcurrentInfo<ISimplusInfo>();



        private void Start()
        {
            _links = new Dictionary<GameObjID, SimplusLink>();
            //_containerInfo = new ConcurrentInfo<ISimplusInfo>();
            _mySimplus = gameObject.transform.parent.gameObject;
            const string pathLink = "Game/SimplusLinkPrefab";
            _linkPrefab = Resources.Load<GameObject>(pathLink);
        }



        private void Update()
        {
            if (_containerInfo.GetState() == HelperStateInfo.None) return;

            ISimplusInfo info = GetInfo(true);

            DestroyExcessLinks(info);
            InitLinks(info);
            UpdateLinks(info);
        }
        public void InitLinks(ISimplusInfo info)
        {
            foreach (ISimplusLinkInfo inf in info.Links)
            {
                if (!_links.ContainsKey(inf.ID))
                {
                    GameObject inst = Instantiate(_linkPrefab);
                    inst.transform.parent = gameObject.transform;
                    SimplusLink link = inst.GetComponent<SimplusLink>();
                    _links.Add(inf.ID, link);
                }
            }
        }
        public void DestroyExcessLinks(ISimplusInfo info)
        {
            foreach (GameObjID id in _links.Keys)
            {
                ISimplusLinkInfo tmp = info.Links.GetObj(id);
                if (tmp == null)
                {
                    Destroy(_links[id].gameObject);
                    _links.Remove(id);
                }
            }
        }
        public void UpdateLinks(ISimplusInfo info)
        {
            foreach (ISimplusLinkInfo inf in info.Links)
            {
                _links[inf.ID].UpdateInfo(inf);
            }
        }

        public void DestroyLinks()
        {
            foreach (GameObjID id in _links.Keys)
            {
                Destroy(_links[id]);
            }
            _links = null;
        }
        public void SetInfo(ISimplusInfo info)
        {
            _containerInfo.SetInfo(info, HelperStateInfo.Update);
        }
        public ISimplusInfo GetInfo(bool flagReset = false)
        {
            KeyValuePair<HelperStateInfo, ISimplusInfo> pair = _containerInfo.GetInfo(flagReset);
            return pair.Value;
        }
    }
}
