using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    interface ISimplus : IGameObj
    {
        void UpdateInfo(ISimplusInfo info);
        IObj2D Obj2D { get; }
        bool IsFocused(Vector2 focusPos);
    }
}
