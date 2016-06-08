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
        public Simplus(ISimplusInfo info)
        {
            _info = info;
        }
        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public bool IsFocused(Vector2 focusPos)
        {
            return _info.Obj2D.IsFocused(focusPos);
        }

        public void UpdateInfo(ISimplusInfo info)
        {
            _info = info;
        }
    }
}
