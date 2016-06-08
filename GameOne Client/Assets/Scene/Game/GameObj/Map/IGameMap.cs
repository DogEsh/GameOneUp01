using System;
using System.Collections.Generic;
using System.Linq;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    interface IGameMap : IGameObj
    {
        void SetToInit(IMapInfo mapInfo);
        void SetToUpdate(IMapInfo mapInfo);
        ISimplus GetFocusedSimplus(Vector2 focusPos);

    }
}
