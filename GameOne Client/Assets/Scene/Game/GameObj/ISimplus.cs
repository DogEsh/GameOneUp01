using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    interface ISimplus
    {
        void UpdateInfo(ISimplusInfo info);
        void Destroy();

    }
}
