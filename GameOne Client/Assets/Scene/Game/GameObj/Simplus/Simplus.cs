using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    class Simplus : MonoBehaviour, ISimplus
    {
        ISimplusInfo _info;

        private const string _pathLink = "wtf";
        private GameObject _linkPrefab;
        private void Start()
        {
            _info = null;
            _linkPrefab = Resources.Load<GameObject>(_pathLink);
        }


        public void Destroy()
        {
            GameObject b = null;
            throw new NotImplementedException();
        }

        public bool IsFocused(Vector2 focusPos)
        {
            if (_info == null) return false;
            return _info.Obj2D.IsFocused(focusPos);
        }

        public void UpdateInfo(ISimplusInfo info)
        {
            _info = info;
        }
    }
}
