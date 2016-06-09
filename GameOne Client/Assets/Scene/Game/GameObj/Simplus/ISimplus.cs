﻿using System;
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
        ISimplusInfo GetInfo();
        bool IsFocused(Vector2 focusPos);
    }
}
