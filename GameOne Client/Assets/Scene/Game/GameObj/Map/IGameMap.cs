using System;
using System.Collections.Generic;
using System.Linq;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public interface IGameMap : IGameObjID
    {
        IMapInfo GetInfo();
        Simplus GetFocusedSimplus(Vector2 focusPos);
        ITransformCoordinate GetTransform();
        void Initialize(ITransformCoordinate tran);
    }
}
