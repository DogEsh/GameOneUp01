using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    public interface ISimplusHPServer : ISimplusHPBase
    {
        bool Attack(int HP);
        void Defense(int HP);
    }
}
