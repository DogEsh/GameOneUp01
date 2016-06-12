using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTeam.GameOne.GameInfo
{
    public interface ISimplusLinkInfo : IGameObjID
    {
        ISimplusInfo Source { get; set; }
        ISimplusInfo Destination { get; set; }
        IObj2D Current { get; set; }
        IObj2D Lost { get; set; }
        SimplusLinkActionState State { get; set; }
    }
}
