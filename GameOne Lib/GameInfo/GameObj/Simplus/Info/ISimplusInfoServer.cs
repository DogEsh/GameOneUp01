using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SimpleTeam.GameOne.GameInfo
{
    public interface ISimplusInfoServer : ISimplusInfoBase
    {
        void IncHP(int HP, ISimplusInfo source);
    }
}