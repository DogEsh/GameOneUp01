using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    public interface ISimplusHPClient : ISimplusHPBase
    {
        void Inc(int HP);
    }
}
