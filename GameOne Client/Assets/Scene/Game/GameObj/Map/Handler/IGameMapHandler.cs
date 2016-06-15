using SimpleTeam.GameOne.GameInfo;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace SimpleTeam.GameOne.Scene
{
    using GameObjID = UInt16;
    interface IGameMapHandler
    {
        void SetToInitInfo(IMapInfo info);
        void SetToUpdateInfo(IMapInfo info);
        IMapInfo GetInfo();
        void Initialize(Dictionary<GameObjID, Simplus> simpluses);
    }
}
