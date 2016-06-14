using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    public interface ISimplus : IGameObjID
    {
        void Initialize(ITransformCoordinate tran);
        ISimplusInfo GetInfo();
        bool IsFocused(Vector2 focusPos);
    }
}
