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
        private GameObject _linkPrefab;


        private IConcurrentInfo<ISimplusInfo> _containerInfo = new ConcurrentInfo<ISimplusInfo>();


        public void SetToUpdateInfo(ISimplusInfo info)
        {
            _containerInfo.SetInfo(info, HelperStateInfo.Update);
        }
        public ISimplusInfo GetInfo()
        {
            return _containerInfo.GetInfo().Value;
        }


        private void Start()
        {
            _links = new Dictionary<GameObjID, SimplusLink>();
            const string pathLink = "Game/SimplusLinkPrefab";
            _linkPrefab = Resources.Load<GameObject>(pathLink);
        }



        private void Update()
        {
            KeyValuePair<HelperStateInfo, ISimplusInfo> pair = _containerInfo.GetInfo(true);
            if (pair.Key == HelperStateInfo.None) return;

            DestroyExcessLinks(pair.Value);
            InitLinks(pair.Value);
            UpdateLinks(pair.Value);
        }

        private void InitLinks(ISimplusInfo info)
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
        private void DestroyExcessLinks(ISimplusInfo info)
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
       private void UpdateLinks(ISimplusInfo info)
        {
            foreach (ISimplusLinkInfo inf in info.Links)
            {
                _links[inf.ID].UpdateInfo(inf);
            }
        }

        private void DestroyLinks()
        {
            foreach (GameObjID id in _links.Keys)
            {
                Destroy(_links[id]);
            }
            _links = null;
        }
 
    }
}
