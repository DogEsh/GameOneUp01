﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    class Simplus : GameObjBase, ISimplus
    {
        ISimplusInfo _info;
        private Dictionary<GameObjID, ISimplusLink> _links = null;
        private const string _pathLink = "Game/SimplusLinkPrefab";
        private GameObject _linkPrefab;

        private enum HelperStateInfo
        {
            None,
            Update
        }
        HelperStateInfo _stateInfo;
        object _lockerInfo = new object();
        public override GameObjID ID
        {
            get
            {
                return _info.ID;
            }
        }
        public IObj2D Obj2D
        {
            get
            {
                return _info.Obj2D;
            }
        }


        private void Start()
        {
            _info = null;
            _links = new Dictionary<GameObjID, ISimplusLink>();
            _linkPrefab = Resources.Load<GameObject>(_pathLink);
        }

        private void Update()
        {
            if (base.CheckDestroy()) return;

            CheckInfo();

            
        }

        private void CheckInfo()
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

        public bool IsFocused(Vector2 focusPos)
        {
            if (_info == null) return false;
            return _info.Obj2D.IsFocused(focusPos);
        }

        public void UpdateInfo(ISimplusInfo info)
        {
            lock (_lockerInfo)
            {
                _info = info;
                _stateInfo = HelperStateInfo.Update;
            }
        }
        public void InitLinks()
        {
            foreach (ISimplusLinkInfo inf in _info.Links)
            {
                if (!_links.ContainsKey(inf.ID))
                {
                    GameObject _inst = Instantiate(_linkPrefab);
                    ISimplusLink link = _inst.GetComponent<ISimplusLink>();
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

        public void DestroyLinks()
        {
            foreach (GameObjID id in _links.Keys)
            {
                _links[id].RequestDestroy();
               
            }
            _links = null;
        }
        public void UpdateLinks()
        {
            foreach (ISimplusLinkInfo inf in _info.Links)
            {
                _links[inf.ID].UpdateInfo(inf);
            }
        }
        public override void Destroy()
        {
            DestroyLinks();
            Destroy(MyInstance);
        }
    }
}
