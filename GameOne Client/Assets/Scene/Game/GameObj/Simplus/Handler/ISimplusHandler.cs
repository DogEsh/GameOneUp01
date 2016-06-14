using System;
using System.Collections.Generic;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    interface ISimplusHandler
    {
        void SetInfo(ISimplusInfo info);
        ISimplusInfo GetInfo();
        void DestroyLinks();
    }
}
