using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace SimpleTeam.GameOne.GameInfo
{
    using GameID = UInt16;
    public interface IMapInfo
    {
        IGameObjContainer<ISimplusInfo> GetContainerSimplus();
    }
}
