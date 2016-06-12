using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;
using UnityEngine;

namespace SimpleTeam.GameOne.Scene
{
    interface ISimplusGraphics
    {
        void Initialize(ISimplusInfo info, ITransformCoordinate tran);
        ISimplusAnimationState GetAnimation();
    }
}
