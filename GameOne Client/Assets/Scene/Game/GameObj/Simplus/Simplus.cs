﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    public class Simplus : GameObjBase, ISimplus
    {
        private ITransformCoordinate _transform;
        private ISimplusInfo _info;
        private Dictionary<GameObjID, ISimplusLink> _links = null;
        private GameObject _linkPrefab;
        //private SimplusGraghics _simplusGraghics;

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

        public void Initialize(ITransformCoordinate tran)
        {
            _transform = tran;
        }

        private void Start()
        {
            _stateInfo = HelperStateInfo.None;
            _links = new Dictionary<GameObjID, ISimplusLink>();
            const string pathLink = "Game/SimplusLinkPrefab";
            _linkPrefab = Resources.Load<GameObject>(pathLink);
            //_simplusGraghics = new SimplusGraghics(gameObject, _info, _transform);
            //_simplusGraghics.SetGraghicsActive(true);
            SimplusGraghics sss = gameObject.GetComponentInChildren<SimplusGraghics>();
            sss.Initialize(gameObject, _info, _transform);
        }

        private void Update()
        {
            if (base.CheckDestroy()) return;
            if (_info == null) return;
            CheckInfo();
            //_simplusGraghics.UpdateGraghics();
      
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
            return _info.Obj2D.IsFocused(focusPos, _transform);
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
            
            Destroy(gameObject);
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
