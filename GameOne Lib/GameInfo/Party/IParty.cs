using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    public interface IParty
    {
        uint ID { get; set; }
        bool IsMy(IParty party);
    }
}
