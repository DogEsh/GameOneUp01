﻿using SimpleTeam.GameOne.GameInfo;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.Scene
{
    interface ISimplusLink : IGameObjID
    {
        void UpdateInfo(ISimplusLinkInfo info);
    }
}
