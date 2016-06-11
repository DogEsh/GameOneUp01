using System;
using System.Collections.Generic;
using System.Linq;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public interface IGameMap : IGameObj
    {
        void InitInfo(IMapInfo info);
        void UpdateInfo(IMapInfo info);
        ISimplus GetFocusedSimplus(Vector2 focusPos);
        IMapInfo GetInfo();
        void Initialize(ITransformCoordinate tran);
    }
}
