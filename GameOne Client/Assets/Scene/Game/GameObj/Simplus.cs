using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    class Simplus : ISimplus
    {
        ISimplusInfo _info;
        public Simplus(ISimplusInfo info)
        {
            _info = info;
        }
        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public void UpdateInfo(ISimplusInfo info)
        {
            _info = info;
        }
    }
}
