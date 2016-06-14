using System;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    class SimplusLink : MonoBehaviour, ISimplusLink
    {
        ISimplusLinkInfo _info;
        public GameObjID ID
        {
            get
            {
                return _info.ID;
            }
        }

        public void UpdateInfo(ISimplusLinkInfo info)
        {
            _info = info;
        }
    }
}
