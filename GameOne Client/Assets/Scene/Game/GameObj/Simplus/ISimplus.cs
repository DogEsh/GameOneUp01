using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    interface ISimplus
    {
        void UpdateInfo(ISimplusInfo info);
        void Destroy();
        bool IsFocused(Vector2 focusPos);
    }
}
